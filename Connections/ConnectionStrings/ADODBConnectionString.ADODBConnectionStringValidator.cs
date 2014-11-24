using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MFramework.Common.Validation;
using FluentValidation;
using MFramework.Common.Validation.DataAnnotations;

namespace MFramework.Infrastructure.Database.Connections.ConnectionStrings
{
    public partial class ADODBConnectionString 
    {
        public class ADODBConnectionStringValidator : MFrameworkValidatorBase<ADODBConnectionString>, MFrameworkValidatorBase<ADODBConnectionString>.UseValidator<ValidatorDataAnnotation<ADODBConnectionString>>
        {
            public ADODBConnectionStringValidator()
            {
                RuleProviderMustBeSpecified.Add();
            }

            private CustomRule RuleProviderMustBeSpecified
            {
                get
                {
                    return
                        Rule()
                            .Must(cnnstr => cnnstr.IsDefined(ADODBConnectionString.Keywords.Provider))
                            .RuleName("RuleProviderMustBeSpecified")
                            .Error("Connection String Error: Database Provider non specificato");
                }
            }
        }
    }
}
