﻿using Weapsy.Domain.ModuleTypes.Events;
using Weapsy.Infrastructure.Caching;
using Weapsy.Infrastructure.Dispatcher;

namespace Weapsy.Data.Reporting.ModuleTypes
{
    public class ModuleTypeEventsHandler : 
        IEventHandler<ModuleTypeCreated>,
        IEventHandler<ModuleTypeDetailsUpdated>
    {
        private readonly ICacheManager _cacheManager;

        public ModuleTypeEventsHandler(ICacheManager cacheManager)
        {
            _cacheManager = cacheManager;
        }

        public void Handle(ModuleTypeCreated @event)
        {
            ClearCache();
        }

        public void Handle(ModuleTypeDetailsUpdated @event)
        {
            ClearCache();
        }

        private void ClearCache()
        {
             _cacheManager.Remove(CacheKeys.ModuleTypesCacheKey);
        }
    }
}