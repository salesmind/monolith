﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SalesMind.Domain.Entities;

namespace SalesMind.Infrastructure.EntityConfigurations;
public class InventoryLogEntityTypeConfiguration: IEntityTypeConfiguration<InventoryLog>
{
    public void Configure(EntityTypeBuilder<InventoryLog> builder)
    {
        builder.ToTable("inventory_logs");
        builder.Property(s => s.Id).HasColumnName("id");
        builder.Property(x => x.Note).HasColumnName("note");
        builder.Property(x => x.ChangeType).HasColumnName("change_type").IsRequired(true).HasConversion<string>();
        builder.Property(x => x.Quantity).HasColumnName("quantity");
        builder.Property(x => x.InventoryId).HasColumnName("inventory_id");
        builder.Property(x => x.CreatedAt).HasColumnName("created_at").HasColumnType("timestamp with time zone").ValueGeneratedOnAdd().HasDefaultValueSql("now()");
        builder.Property(x => x.ModifiedAt).HasColumnName("modified_at").HasColumnType("timestamp with time zone").ValueGeneratedOnAddOrUpdate().HasDefaultValueSql("now()");

        builder.HasOne(x => x.Inventory).WithMany().HasForeignKey(x => x.InventoryId);
    }
}