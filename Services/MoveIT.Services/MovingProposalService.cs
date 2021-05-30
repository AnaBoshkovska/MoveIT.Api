using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using MoveIT.Core;
using MoveIT.Core.Models;
using MoveIT.Core.Services;
using Microsoft.Extensions.Logging;

namespace MoveIT.Services
{
    public class MovingProposalService : IMovingProposalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMovingPriceCalculator _movingPriceCalculator;
        private readonly ILogger<MovingProposalService> _logger;

        public MovingProposalService(IUnitOfWork unitOfWork, IMovingPriceCalculator movingPriceCalculator, ILogger<MovingProposalService> logger)
        {
            _unitOfWork = unitOfWork;
            _movingPriceCalculator = movingPriceCalculator;
            _logger = logger;
        }

        public async Task<IEnumerable<MovingProposalPrice>> GetAll(Guid userId)
        {
            try
            {
                var items = await _unitOfWork.MovingProposals.GetAllAsync(userId);
                var result = new List<MovingProposalPrice>();
                foreach (var item in items)
                {
                    var res = new MovingProposalPrice(item);
                    res.Price = _movingPriceCalculator.CalculatePrice(res);
                    result.Add(res);
                }
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has occured while attempting to retrieve items of type {type} for user {userId}: {ex}", typeof(MovingProposal), userId, ex.Message);
                return null;
            }        
        }

        public async Task<MovingProposalPrice> Get(Guid id, Guid userId)
        {
            try
            {
                var result = await _unitOfWork.MovingProposals.GetByIdAsync(id, userId);
                if (result == null)
                    return null;

                var movingProposalPrice = new MovingProposalPrice(result);
                movingProposalPrice.Price = _movingPriceCalculator.CalculatePrice(movingProposalPrice);

                return movingProposalPrice;
            }
            catch(Exception ex)
            {
                _logger.LogError("An error has occured while attempting to retrieve item of type {type} with id {id}: {ex}", typeof(MovingProposal), id, ex.Message);
                return null;
            }           
        }

        public async Task<MovingProposalPrice> Create(MovingProposal movingProposal)
        {
            try
            {
                movingProposal.CreateDate = movingProposal.LastUpdateDate = DateTime.Now;
                await _unitOfWork.MovingProposals.AddAsync(movingProposal);
                await _unitOfWork.CommitAsync();

                movingProposal = await _unitOfWork.MovingProposals.GetByIdAsync(movingProposal.Id);
                var result = new MovingProposalPrice(movingProposal);
                result.Price = _movingPriceCalculator.CalculatePrice(result);
                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError("An error has occured while attempting to create item of type {type}: {ex}", typeof(MovingProposal), ex.Message);
                return null;
            }    
        }

        public async Task Update(MovingProposal movingProposal)
        {
            try
            {
                movingProposal.LastUpdateDate = DateTime.Now;             
                _unitOfWork.MovingProposals.Update(movingProposal);
                await _unitOfWork.CommitAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError("An error has occured while attempting to update item of type {type} with id {id}: {ex}", typeof(MovingProposal), movingProposal.Id, ex.Message);
            }         
        }

        public async Task Delete(MovingProposal movingProposal)
        {
            try
            {
                _unitOfWork.MovingProposals.Remove(movingProposal);
                await _unitOfWork.CommitAsync();
            }
            catch(Exception ex)
            {
                _logger.LogError("An error has occured while attempting to delete item of type {type} with id {id}: {ex}", typeof(MovingProposal), movingProposal.Id, ex.Message);
            }         
        }
    }
}
