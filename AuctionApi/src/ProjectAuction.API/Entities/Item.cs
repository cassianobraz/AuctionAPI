﻿using System.ComponentModel.DataAnnotations.Schema;
using ProjectAuction.API.Enums;

namespace ProjectAuction.API.Entities;

[Table("Items")]
public class Item
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Brand { get; set; } = string.Empty;
    public Condition Condition { get; set; }
    public decimal BasePrice { get; set; }
    public int AuctionId { get; set; }
}
