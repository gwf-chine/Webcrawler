using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Service.CommandProcessor;
using Service.Core.Common;

namespace Service.CommandProcessor.Command
{
    public interface IValidationHandler<in TCommand> where TCommand : ICommand
    {
        IEnumerable<ValidationResult>  Validate(TCommand command);
    }
}
