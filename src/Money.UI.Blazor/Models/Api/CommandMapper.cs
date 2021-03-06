﻿using Money.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money.Models.Api
{
    public class CommandMapper : TypeMapper
    {
        public CommandMapper()
        {
            Add<CreateOutcome>("outcome-create");
            Add<ChangeOutcomeAmount>("outcome-change-amount");
            Add<ChangeOutcomeDescription>("outcome-change-description");
            Add<ChangeOutcomeWhen>("outcome-change-when");
            Add<DeleteOutcome>("outcome-delete");

            Add<CreateCategory>("category-create");
            Add<ChangeCategoryColor>("category-change-color");
            Add<ChangeCategoryIcon>("category-change-icon");
            Add<ChangeCategoryDescription>("category-change-description");
            Add<RenameCategory>("category-rename");
            Add<DeleteCategory>("category-delete");

            Add<CreateCurrency>("currency-create");
            Add<ChangeCurrencySymbol>("currency-change-symbol");
            Add<SetCurrencyAsDefault>("currency-set-as-default");
            Add<SetExchangeRate>("currency-exchangerate-set");
            Add<RemoveExchangeRate>("currency-exchangerate-remove");
            Add<DeleteCurrency>("currency-delete");
        }
    }
}
