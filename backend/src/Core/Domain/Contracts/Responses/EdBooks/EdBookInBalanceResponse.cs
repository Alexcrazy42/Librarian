﻿using Domain.Enums;

namespace Domain.Contracts.Responses.EdBooks; 

public class EdBookInBalanceResponse 
{
    public Guid Id { get; set; }

    public BaseEdBookResponse BaseEdBook { get; set; }

    public decimal Price { get; set; }

    public BookCondition Condition { get; set; }

    public int Year { get; set; }

    public string Note { get; set; }

    public int InPlaceCount { get; set; }

    public int TotalCount { get; set; }

    public Guid? SupplyId { get; set; }

    public Guid? GroundId { get; set; }

    public bool InStock { get; set; }
}
