﻿using MediatR;
using TS.Result;

namespace server.Application.Features.Customers.CreateCustomer;

public sealed record CreateCustomerCommand(
    string Name,
    string TaxDepartment,
    string TaxNumber,
    string City,
    string Town,
    string FullAdress
) : IRequest<Result<string>>;