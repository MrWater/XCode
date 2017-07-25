using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XCode.Module.SimplePS.Geometry.GeometrySpecialAction
{
    delegate void SpecialActionEventHandler(Style.GeometryStyleBase style);

    internal class SpecialActionPool
    {
        public static readonly SpecialActionPool Default;

        private Dictionary<Type, SpecialActionGroup> _ActionList;

        public SpecialActionGroup this[Type type]
        {
            get
            {
                if(_ActionList.ContainsKey(type))
                {
                    return _ActionList[type];
                }

                return null;
            }
        }

        private SpecialActionPool()
        {
            Init();
        }

        private void Init()
        {
            _ActionList = new Dictionary<Type, SpecialActionGroup>();
            _ActionList[typeof(Line)] = new SpecialActionGroup();
            _ActionList[typeof(Circle)] = new SpecialActionGroup();
            _ActionList[typeof(Image)] = new SpecialActionGroup();
            _ActionList[typeof(Rectangle)] = new SpecialActionGroup();
            _ActionList[typeof(Triangle)] = new SpecialActionGroup();
            _ActionList[typeof(Text)] = new SpecialActionGroup();
        }

        static SpecialActionPool()
        {
            Default = new SpecialActionPool();
        }
    }
}
