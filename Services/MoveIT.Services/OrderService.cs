using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using Microsoft.Extensions.Logging;

using MoveIT.Core;
using MoveIT.Core.Models;
using MoveIT.Core.Services;

namespace MoveIT.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<OrderService> _logger;

        public OrderService(IUnitOfWork unitOfWork, ILogger<OrderService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<Order>> GetAll(Guid userId)
        {
            try
            {
                return await _unitOfWork.MovingOrders.GetAllAsync(userId);
            }
            catch(Exception ex)
            {
                _logger.LogError("An error has occured while attempting to retrieve items of type {type} for user {userId}: {ex}", typeof(Order), userId, ex.Message);
                return null;
            }        
        }

        public async Task<Order> Get(Guid id, Guid userId)
        {       
            try
            {
                return await _unitOfWork.MovingOrders.GetByIdAsync(id, userId);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has occured while attempting to retrieve item of type {type} with id {id}: {ex}", typeof(Order), id, ex.Message);
                return null;
            }
        }

        public async Task<Order> GetByMovingProposalId(Guid movingProposalId, Guid userId)
        {
            try
            {
                var result = await _unitOfWork.MovingOrders.GetByMovingProposalId(movingProposalId);
                if (result == null ||  result.MovingProposal == null || result.MovingProposal.UserId != userId)
                    return null;
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has occured while attempting to retrieve item of type {type} with moving proposal id {id}: {ex}", typeof(Order), movingProposalId, ex.Message);
                return null;
            }          
        }

        public async Task<Order> Create(Order order)
        {
            try
            {
                order.CreateDate = order.LastUpdateDate = DateTime.Now;
                await _unitOfWork.MovingOrders.AddAsync(order);
                await _unitOfWork.CommitAsync();
                return order;
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has occured while attempting to create item of type {type}: {ex}", typeof(Order), ex.Message);
                return null;
            }
        }

        public async Task Delete(Order order)
        {
            try
            {
                _unitOfWork.MovingOrders.Remove(order);
                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error has occured while attempting to delete item of type {type} with id {id}: {ex}", typeof(Order), order.Id, ex.Message);
            }       
        }
    }
}
