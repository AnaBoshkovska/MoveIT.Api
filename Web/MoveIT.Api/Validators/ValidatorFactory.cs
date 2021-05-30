using System;
using System.Collections.Generic;

using FluentValidation;

using MoveIT.Api.Dto;

namespace MoveIT.Api.Validators
{
    public class ValidatorFactory
    {
        private static Dictionary<Type, IValidator> _validators = new Dictionary<Type, IValidator>()
        {
            { typeof(CreateMovingProposal), new MovingProposalValidator()},
            { typeof(CreateOrder), new MovingOrderValidator()},
            { typeof(RegisterUser), new UserRegisterValidator()}
        };

        public static AbstractValidator<T> GetVaidator<T>()
        {
            if(_validators.TryGetValue(typeof(T), out var validator))
            {
                return (AbstractValidator<T>)validator;
            }
            throw new Exception("Validator could not be found");
        }
    }
}
