﻿using Money.Commands.Handlers;
using Neptuo;
using Neptuo.Activators;
using Neptuo.Bootstrap;
using Neptuo.Commands;
using Neptuo.Models.Keys;
using Neptuo.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Money
{
    public class BootstrapTask : IBootstrapTask
    {
        private readonly ICommandHandlerCollection commandHandlers;
        private readonly IFactory<IRepository<Outcome, IKey>> outcomeRepository;
        private readonly IFactory<IRepository<Category, IKey>> categoryRepository;
        private readonly IFactory<IRepository<CurrencyList, IKey>> currencyListRepository;

        public BootstrapTask(ICommandHandlerCollection commandHandlers, 
            IFactory<IRepository<Outcome, IKey>> outcomeRepository,
            IFactory<IRepository<Category, IKey>> categoryRepository,
            IFactory<IRepository<CurrencyList, IKey>> currencyListRepository)
        {
            Ensure.NotNull(commandHandlers, "commandHandlers");
            Ensure.NotNull(outcomeRepository, "outcomeRepository");
            Ensure.NotNull(categoryRepository, "categoryRepository");
            Ensure.NotNull(currencyListRepository, "currencyListRepository");
            this.commandHandlers = commandHandlers;
            this.outcomeRepository = outcomeRepository;
            this.categoryRepository = categoryRepository;
            this.currencyListRepository = currencyListRepository;
        }

        public void Initialize()
        {
            OutcomeHandler outcomeHandler = new OutcomeHandler(outcomeRepository);
            commandHandlers.AddAll(outcomeHandler);

            CategoryHandler categoryHandler = new CategoryHandler(categoryRepository);
            commandHandlers.AddAll(categoryHandler);

            CurrencyHandler currencyHandler = new CurrencyHandler(currencyListRepository);
            commandHandlers.AddAll(currencyHandler);
        }
    }
}
