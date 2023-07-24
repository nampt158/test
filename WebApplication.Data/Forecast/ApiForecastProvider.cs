using System;
using WebApplication.Domain;

namespace WebApplication.Data.Forecast
{
    internal class ApiForecastProvider : IForecastProvider
    {
        private readonly Func<IForecastProvider.ICityQuery> _queryFactory;
        
        public ApiForecastProvider(Func<IForecastProvider.ICityQuery> queryFactory)
        {
            _queryFactory = queryFactory;
        }

        public IForecastProvider.ICityQuery Forecasts => _queryFactory();
    }
}