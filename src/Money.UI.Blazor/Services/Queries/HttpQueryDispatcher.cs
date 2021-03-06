﻿using Money.Services;
using Neptuo.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neptuo.Queries
{
    internal partial class HttpQueryDispatcher : IQueryDispatcher
    {
        private readonly ApiClient api;
        private readonly FormatterContainer formatters;
        private readonly ILog log;
        private readonly IEnumerable<IMiddleware> middlewares;

        public HttpQueryDispatcher(ApiClient api, FormatterContainer formatters, ILogFactory logFactory, IEnumerable<IMiddleware> middlewares)
        {
            Ensure.NotNull(api, "api");
            Ensure.NotNull(formatters, "formatters");
            Ensure.NotNull(logFactory, "logFactory");
            Ensure.NotNull(middlewares, "middlewares");
            this.api = api;
            this.formatters = formatters;
            this.middlewares = middlewares;
            this.log = logFactory.Scope("HttpQueryDispatcher");
        }

        public async Task<TOutput> QueryAsync<TOutput>(IQuery<TOutput> query)
        {
            CollectionMiddleware middleware = new CollectionMiddleware(middlewares);
            TOutput output = (TOutput)await middleware.ExecuteAsync(query, this, new DefaultMiddleware<TOutput>(api, formatters, log).ExecuteRawAsync);
            return output;
        }
    }
}
