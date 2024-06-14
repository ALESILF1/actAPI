using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.ViewModel.Rota;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architecture.Service.Interface
{
    public interface IRotaService : IBaseService<Rota>
    {
        Task Add(CreateRotaVM inputModel);
        Task Delete(int id);
        Task<RotaVM> FindCheapestRoute(string origin, string destination);
        Task<IEnumerable<RotaVM>> Get();
        Task<RotaVM> GetById(int id);
        Task Update(RotaVM inputModel);
    }
}
