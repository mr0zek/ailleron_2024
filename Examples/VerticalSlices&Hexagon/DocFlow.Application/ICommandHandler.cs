using System;
using System.Collections.Generic;
using System.Text;

namespace DocFlow.Application
{
  public interface ICommandHandler<in T>
  {
    void Handle(T command);    
  }
}
