﻿using System.Collections.Generic;
using System.Linq;

namespace HangFire.Filters
{
    /// <summary>
    /// Encapsulates information about the available job filters.
    /// </summary>
    internal class JobFilterInfo
    {
        private readonly List<IClientFilter> _clientFilters = new List<IClientFilter>();
        private readonly List<IServerFilter> _serverFilters = new List<IServerFilter>();
        private readonly List<IStateChangingFilter> _stateChangingFilters = new List<IStateChangingFilter>();
        private readonly List<IStateChangedFilter> _stateChangedFilters = new List<IStateChangedFilter>();
        private readonly List<IClientExceptionFilter> _clientExceptionFilters = new List<IClientExceptionFilter>(); 
        private readonly List<IServerExceptionFilter> _serverExceptionFilters = new List<IServerExceptionFilter>(); 

        /// <summary>
        /// Gets all the client filters in the application.
        /// </summary>
        /// 
        /// <returns>
        /// The client filters.
        /// </returns>
        public IList<IClientFilter> ClientFilters
        {
            get { return _clientFilters; }
        }

        /// <summary>
        /// Gets all the server filters in the application.
        /// </summary>
        /// 
        /// <returns>
        /// The server filters.
        /// </returns>
        public IList<IServerFilter> ServerFilters
        {
            get { return _serverFilters; }
        }

        /// <summary>
        /// Gets all the stat changing filters in the application.
        /// </summary>
        /// 
        /// <returns>
        /// The state changing filters.
        /// </returns>
        public IList<IStateChangingFilter> StateChangingFilters
        {
            get { return _stateChangingFilters; }
        }

        /// <summary>
        /// Gets all the state changed filters in the application.
        /// </summary>
        /// 
        /// <returns>
        /// The state changed filters.
        /// </returns>
        public IList<IStateChangedFilter> StateChangedFilters
        {
            get { return _stateChangedFilters; }
        }

        /// <summary>
        /// Gets all the client exception filters in the application.
        /// </summary>
        /// 
        /// <returns>
        /// The client exception filters.
        /// </returns>
        public IList<IClientExceptionFilter> ClientExceptionFilters
        {
            get { return _clientExceptionFilters; }
        }

        /// <summary>
        /// Gets all the server exception filters in the application.
        /// </summary>
        /// 
        /// <returns>
        /// The server exception filters.
        /// </returns>
        public IList<IServerExceptionFilter> ServerExceptionFilters
        {
            get { return _serverExceptionFilters; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobFilterInfo"/> class.
        /// </summary>
        public JobFilterInfo()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JobFilterInfo"/> class using the specified filters collection.
        /// </summary>
        /// <param name="filters">The filters collection.</param>
        public JobFilterInfo(IEnumerable<JobFilter> filters)
        {
            var list = filters.Select(f => f.Instance).ToList();

            _clientFilters.AddRange(list.OfType<IClientFilter>());
            _serverFilters.AddRange(list.OfType<IServerFilter>());

            _stateChangingFilters.AddRange(list.OfType<IStateChangingFilter>());
            _stateChangedFilters.AddRange(list.OfType<IStateChangedFilter>());

            _clientExceptionFilters.AddRange(list.OfType<IClientExceptionFilter>());
            _serverExceptionFilters.AddRange(list.OfType<IServerExceptionFilter>());
        }
    }
}
