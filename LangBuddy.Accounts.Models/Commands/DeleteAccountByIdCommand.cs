using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LangBuddy.Accounts.Models.Commands
{
    public record DeleteAccountByIdCommand(long Id): IRequest;
}
