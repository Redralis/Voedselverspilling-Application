using Domain;
using Domain.Services;

namespace VoedselVerspillingApi.GraphQL  
{  
    public class Query
    {
        private readonly IMealBoxRepository _mealBoxRepository;
        private List<MealBox> list = new();

        public Query(IMealBoxRepository mealBoxRepository)
        {
            _mealBoxRepository = mealBoxRepository;
            list = _mealBoxRepository.GetMealBoxes();
        }

        public IQueryable<MealBox> GetMealBoxes() => list.AsQueryable();
    }  
}