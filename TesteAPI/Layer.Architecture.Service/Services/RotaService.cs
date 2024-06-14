using AutoMapper;
using Layer.Architecture.Domain.Entities;
using Layer.Architecture.Domain.ViewModel.Rota;
using Layer.Architecture.Infra.Data.Interface;
using Layer.Architecture.Service.Interface;
using Layer.Architecture.Service.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Layer.Architecture.Service.Services
{
    public class RotaService : BaseService<Rota>, IRotaService
    {
        private readonly IRotaRepository _RotaRepository;
        private readonly IMapper _mapper;

        public RotaService(IRotaRepository RotaRepository, IMapper mapper)
        {
            _RotaRepository = RotaRepository;
            _mapper = mapper;

        }


        public async Task Add(CreateRotaVM inputModel)
        {
            try
            {
                var entity = _mapper.Map<Rota>(inputModel);

                Validate(entity, Activator.CreateInstance<RotaValidator>());
                var ret = await _RotaRepository.Insert(entity);
            }
            catch (AggregateException ex)
            {
                throw new AggregateException(ex.Message);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task Delete(int id) => await _RotaRepository.Delete(id);

        public async Task<IEnumerable<RotaVM>> Get()
        {
            var entities = await _RotaRepository.Select();

            var outputModels = entities.Select(s => _mapper.Map<RotaVM>(s));

            return outputModels;
        }

        public async Task<RotaVM> GetById(int id)
        {
            var entity = await _RotaRepository.Select(id);

            var outputModel = _mapper.Map<RotaVM>(entity);

            return outputModel;
        }

        public async Task Update(RotaVM inputModel)
        {
            var entity = _mapper.Map<Rota>(inputModel);
            //var RotaDB = await _RotaRepository.Select(inputModel.Id);
            //if (RotaDB == null)
            //{
            //    throw new Exception("Rota Inválido");
            //};
            Validate(entity, Activator.CreateInstance<RotaValidator>());
            await _RotaRepository.Update(entity);
        }
        public async Task<RotaVM> FindCheapestRoute(string origin, string destination)
        {


            var routes = _RotaRepository.Select().Result;
            var graph = new Dictionary<string, List<(string Destination, int Cost)>>();

            // Construir o grafo a partir das rotas
            foreach (var route in routes)
            {
                if (!graph.ContainsKey(route.Origin))
                {
                    graph[route.Origin] = new List<(string, int)>();
                }
                graph[route.Origin].Add((route.Destination, route.Cost));

                // Também precisamos garantir que todos os destinos estão no grafo
                if (!graph.ContainsKey(route.Destination))
                {
                    graph[route.Destination] = new List<(string, int)>();
                }
            }

            var costs = new Dictionary<string, int>();
            var parents = new Dictionary<string, string>();
            var processed = new HashSet<string>();

            // Inicializar os custos e os pais
            foreach (var node2 in graph.Keys)
            {
                costs[node2] = int.MaxValue;
            }
            costs[origin] = 0;

            string FindLowestCostNode()
            {
                var lowestCost = int.MaxValue;
                string lowestCostNode = null;

                foreach (var node in costs.Keys)
                {
                    var cost = costs[node];
                    if (cost < lowestCost && !processed.Contains(node))
                    {
                        lowestCost = cost;
                        lowestCostNode = node;
                    }
                }
                return lowestCostNode;
            }

            var node = FindLowestCostNode();
            while (node != null)
            {
                var cost = costs[node];
                var neighbors = graph.ContainsKey(node) ? graph[node] : new List<(string, int)>();

                foreach (var (neighbor, neighborCost) in neighbors)
                {
                    var newCost = cost + neighborCost;
                    if (newCost < costs[neighbor])
                    {
                        costs[neighbor] = newCost;
                        parents[neighbor] = node;
                    }
                }
                processed.Add(node);
                node = FindLowestCostNode();
            }

            if (!costs.ContainsKey(destination) || costs[destination] == int.MaxValue)
            {
                return null; // No path found
            }

            var path = new List<string>();
            var current = destination;

            while (current != origin)
            {
                if (!parents.ContainsKey(current))
                {
                    return null; // No path found
                }
                path.Insert(0, current);
                current = parents[current];
            }
            path.Insert(0, origin);

            var result = string.Join(" - ", path);
            var totalCost = costs[destination];
            var retorno = new RotaVM();
            retorno.Cost = totalCost;
            retorno.Origin = origin;
            retorno.Destination = destination;
            retorno.BestRoute = $"{result} ao custo de ${totalCost}";
            return retorno;
        }
    }
}
