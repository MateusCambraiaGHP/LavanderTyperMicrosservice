﻿using FluentValidation.Results;
using MediatR;

namespace LTW.Core.Messages.CommonMessages
{
  public abstract class BaseMessage<TResponse> : IRequest<TResponse>
  {
    public DateTime ExecTime { get; }
    public List<ValidationFailure> ValidationResult { get; set; }

    public BaseMessage()
    {
      ExecTime = DateTime.Now;
      ValidationResult = new List<ValidationFailure>();
    }

    public virtual bool IsValid() => ValidationResult.Count == 0;
  }
}
