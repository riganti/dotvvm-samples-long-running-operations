using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotVVM.Framework.Binding;
using DotVVM.Framework.Binding.Expressions;
using DotVVM.Framework.Controls;

namespace LongRunningOperationsSample.Controls
{
    public class LongRunningProgress : DotvvmMarkupControl
    {

        public ICommandBinding OnCompleted
        {
            get { return (ICommandBinding)GetValue(OnCompletedProperty); }
            set { SetValue(OnCompletedProperty, value); }
        }
        public static readonly DotvvmProperty OnCompletedProperty
            = DotvvmProperty.Register<ICommandBinding, LongRunningProgress>(c => c.OnCompleted, null);

        public ICommandBinding OnFailed
        {
            get { return (ICommandBinding)GetValue(OnFailedProperty); }
            set { SetValue(OnFailedProperty, value); }
        }
        public static readonly DotvvmProperty OnFailedProperty
            = DotvvmProperty.Register<ICommandBinding, LongRunningProgress>(c => c.OnFailed, null);



    }
}
