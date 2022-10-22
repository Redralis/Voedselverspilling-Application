using Domain;
using Domain.Services;

namespace VoedselVerspillingApi.GraphQL  
{  
    public class Query
    {
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable because it is used with DI
        // and local initialization would lead to strong coupling.
        private readonly IMealBoxRepository _mealBoxRepository;
        private readonly List<MealBox> _list;

        public Query(IMealBoxRepository mealBoxRepository)
        {
            _mealBoxRepository = mealBoxRepository;
            _list = _mealBoxRepository.GetMealBoxes();
        }

        public IQueryable<MealBox> GetMealBoxes() => _list.AsQueryable();
    }  
}