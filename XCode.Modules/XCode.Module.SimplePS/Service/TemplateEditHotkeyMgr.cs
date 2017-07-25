using XCode.Module.SimplePS.Common.Hotkey;
using XCode.Module.SimplePS.Common.Paint;
using XCode.Module.SimplePS.Geometry;
using XCode.Module.SimplePS.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using XCode.Module.SimplePS.Geometry.GeometrySpecialAction;
using XCode.Module.SimplePS.Geometry.GeometrySpecialAction.Action;

namespace XCode.Module.SimplePS.Service
{

    internal class TemplateEditHotkeyMgr
    {
        private static TemplateEditView _view;
        private static bool _registed;
        private static IntPtr _registedHandle;

        #region 热键所需
        private static short _atomV; // 移动工具
        private static short _atomL; // 线条 
        private static short _atomR; // 矩形
        private static short _atomT; // 三角形
        private static short _atomC; // 圆形
        private static short _atomI; // 图片
        private static short _atomW; // 文字
        private static short _atomQ; // 二维码
        private static short _atomCtrlZ; // 撤销
        private static short _atomCtrlY; //重做
        private static Dictionary<int, System.Action> _actionWithHotkey;
        #endregion

        private static bool _shiftPressed;

        /// <summary>
        /// 取消热键
        /// </summary>
        /// <param name="view"></param>
        private static void Unregister(TemplateEditView view)
        {
            if (_registedHandle == default(IntPtr))
                return;

            //向全局原子表取消申请唯一标识符
            Hotkey.GlobalDeleteAtom(_atomL);
            Hotkey.GlobalDeleteAtom(_atomR);
            Hotkey.GlobalDeleteAtom(_atomV);
            Hotkey.GlobalDeleteAtom(_atomT);
            Hotkey.GlobalDeleteAtom(_atomC);
            Hotkey.GlobalDeleteAtom(_atomI);
            Hotkey.GlobalDeleteAtom(_atomW);
            Hotkey.GlobalDeleteAtom(_atomQ);
            Hotkey.GlobalDeleteAtom(_atomCtrlZ);
            Hotkey.GlobalDeleteAtom(_atomCtrlY);

            //取消关联热键对应的行为
            _actionWithHotkey = new Dictionary<int, System.Action>();
            //_registedHwndSource.RemoveHook(WndProc);

            //取消注册热键
            Hotkey.UnregisterHotKey(_registedHandle, _atomL);
            Hotkey.UnregisterHotKey(_registedHandle, _atomR);
            Hotkey.UnregisterHotKey(_registedHandle, _atomV);
            Hotkey.UnregisterHotKey(_registedHandle, _atomT);
            Hotkey.UnregisterHotKey(_registedHandle, _atomC);
            Hotkey.UnregisterHotKey(_registedHandle, _atomI);
            Hotkey.UnregisterHotKey(_registedHandle, _atomW);
            Hotkey.UnregisterHotKey(_registedHandle, _atomQ);
            Hotkey.UnregisterHotKey(_registedHandle, _atomCtrlZ);
            Hotkey.UnregisterHotKey(_registedHandle, _atomCtrlY);

            _registed = false;
            Debug.WriteLine("取消热键");
        }

        /// <summary>
        /// 注册热键
        /// </summary>
        /// <param name="view"></param>
        public static void Register(TemplateEditView view)
        {
            if (view == null)
                return;


            if (_registedHandle == default(IntPtr))
            {
                var ps = PresentationSource.FromVisual(view);

                if (ps != null)
                {
                    HwndSource hs = ps as HwndSource;

                    if (hs != null)
                    {
                        _registedHandle = hs.Handle;
                    }
                }
            }
            
            if(_registedHandle != default(IntPtr))
            {
                if (_registed)
                {
                    Unregister(view);
                }

                _view = view;

                //向全局原子表申请唯一标识符
                _atomL = Hotkey.GlobalAddAtom("L");
                _atomR = Hotkey.GlobalAddAtom("R");
                _atomV = Hotkey.GlobalAddAtom("V");
                _atomT = Hotkey.GlobalAddAtom("T");
                _atomC = Hotkey.GlobalAddAtom("C");
                _atomI = Hotkey.GlobalAddAtom("I");
                _atomW = Hotkey.GlobalAddAtom("W");
                _atomQ = Hotkey.GlobalAddAtom("Q");
                _atomCtrlZ = Hotkey.GlobalAddAtom("Ctrl-Z");
                _atomCtrlY = Hotkey.GlobalAddAtom("Ctrl-Y");

                //关联热键对应的行为
                _actionWithHotkey = new Dictionary<int, System.Action>();
                _actionWithHotkey[_atomL] = delegate { view.RBLine.IsChecked = true; };
                _actionWithHotkey[_atomR] = delegate { view.RBRectangle.IsChecked = true; };
                _actionWithHotkey[_atomV] = delegate { view.RBDrag.IsChecked = true; };
                _actionWithHotkey[_atomT] = delegate { view.RBTriangle.IsChecked = true; };
                _actionWithHotkey[_atomC] = delegate { view.RBCircle.IsChecked = true; };
                _actionWithHotkey[_atomI] = delegate { view.RBImage.IsChecked = true; };
                _actionWithHotkey[_atomW] = delegate { view.RBText.IsChecked = true; };
                _actionWithHotkey[_atomQ] = delegate { view.RBQRCode.IsChecked = true; };
                _actionWithHotkey[_atomCtrlZ] = delegate { };
                _actionWithHotkey[_atomCtrlY] = delegate { };

                //注册热键
                Hotkey.RegisterHotKey(_registedHandle, _atomL, Hotkey.KeyModifiers.None, (int)Hotkey.Keys.L);
                Hotkey.RegisterHotKey(_registedHandle, _atomR, Hotkey.KeyModifiers.None, (int)Hotkey.Keys.R);
                Hotkey.RegisterHotKey(_registedHandle, _atomV, Hotkey.KeyModifiers.None, (int)Hotkey.Keys.V);
                Hotkey.RegisterHotKey(_registedHandle, _atomT, Hotkey.KeyModifiers.None, (int)Hotkey.Keys.T);
                Hotkey.RegisterHotKey(_registedHandle, _atomC, Hotkey.KeyModifiers.None, (int)Hotkey.Keys.C);
                Hotkey.RegisterHotKey(_registedHandle, _atomI, Hotkey.KeyModifiers.None, (int)Hotkey.Keys.I);
                Hotkey.RegisterHotKey(_registedHandle, _atomW, Hotkey.KeyModifiers.None, (int)Hotkey.Keys.W);
                Hotkey.RegisterHotKey(_registedHandle, _atomQ, Hotkey.KeyModifiers.None, (int)Hotkey.Keys.Q);
                Hotkey.RegisterHotKey(_registedHandle, _atomCtrlZ, Hotkey.KeyModifiers.Ctrl, (int)Hotkey.Keys.Z);
                Hotkey.RegisterHotKey(_registedHandle, _atomCtrlY, Hotkey.KeyModifiers.Ctrl, (int)Hotkey.Keys.Y);

                _registed = true;
                Debug.WriteLine("注册热键");
                
            }
        }
        
        /// <summary>
        /// 添加钩子
        /// </summary>
        /// <param name="view"></param>
        public static void InitHook(TemplateEditView view)
        {
            var ps = PresentationSource.FromVisual(view);

            if (ps != null)
            {
                HwndSource hs = ps as HwndSource;

                if(hs != null)
                {
                    hs.AddHook(WndProc);
                }
            }
        }

        private static void RegisterShiftPressedAction()
        {
            var strategy = SpecialActionPool.Default[typeof(Line)];
            if (strategy != null)
            {
                strategy.Add(DrawLineWithShiftAction.Instance);
            }
        }

        private static void UnregisterShiftPressedAction()
        {
            var strategy = SpecialActionPool.Default[typeof(Line)];
            if (strategy != null)
            {
                strategy.Remove(DrawLineWithShiftAction.Instance);
            }
        }

        private static IntPtr WndProc(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                //按下松开才会响应
                case Hotkey.WM_HOTKEY:
                    {
                        int sid = wParam.ToInt32();

                        if (_actionWithHotkey.ContainsKey(sid))
                        {
                            _actionWithHotkey[sid]();
                        }
                    }

                    break;

                case Hotkey.WM_KEYDOWN:
                    {
                        switch (wParam.ToInt32())
                        {
                            case (int)Hotkey.Keys.VK_SHIFT:
                                if(!_shiftPressed)
                                {
                                    _shiftPressed = true;
                                    RegisterShiftPressedAction();
                                }
                                break;
                        }
                    }

                    break;

                case Hotkey.WM_KEYUP:
                    {
                        switch(wParam.ToInt32())
                        {
                            case (int)Hotkey.Keys.VK_SHIFT:
                                _shiftPressed = false;
                                UnregisterShiftPressedAction();
                                break;
                        }
                    }

                    break;

                case Hotkey.WM_ACTIVE:
                    if (wParam.ToInt32() == Hotkey.WA_ACTIVE)
                    {
                        if (!_registed)
                        {
                            Register(_view);
                        }
                    }
                    else
                    {
                        if (_registed)
                        {
                            Unregister(_view);
                        }
                    }
                    break;

                default:
                    break;
            }

            return IntPtr.Zero;
        }
    }
}
