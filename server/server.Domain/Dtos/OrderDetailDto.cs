﻿namespace server.Domain.Dtos;

public sealed record OrderDetailDto(
  Guid ProductId,
  decimal Quantity,
  decimal Price);