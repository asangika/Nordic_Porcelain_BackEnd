﻿// <auto-generated />
using System;
using Ecommerce.Infrastructure.src.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Ecommerce.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240908074917_InitialDb")]
    partial class InitialDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Ecommerce.Domain.src.Shared.BaseEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.HasKey("Id");

                    b.ToTable("base_entity", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Ecommerce.Domain.src.AddressAggregate.Address", b =>
                {
                    b.HasBaseType("Ecommerce.Domain.src.Shared.BaseEntity");

                    b.Property<string>("AddressLine1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("address_line1");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("text")
                        .HasColumnName("address_line2");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("city");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("country");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("postal_code");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("street_number");

                    b.Property<string>("UnitNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("unit_number");

                    b.ToTable("Addresses", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Domain.src.CategoryAggregate.Category", b =>
                {
                    b.HasBaseType("Ecommerce.Domain.src.Shared.BaseEntity");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("name");

                    b.Property<Guid>("ParentCategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("parent_category_id");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Domain.src.Entities.OrderAggregate.Order", b =>
                {
                    b.HasBaseType("Ecommerce.Domain.src.Shared.BaseEntity");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("order_date");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("integer")
                        .HasColumnName("order_status");

                    b.Property<Guid>("ShippingAddressId")
                        .HasColumnType("uuid")
                        .HasColumnName("shipping_address_id");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("total_price");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasIndex("ShippingAddressId")
                        .HasDatabaseName("ix_orders_shipping_address_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_orders_user_id");

                    b.ToTable("Orders", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Domain.src.Entities.OrderAggregate.OrderItem", b =>
                {
                    b.HasBaseType("Ecommerce.Domain.src.Shared.BaseEntity");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("price");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer")
                        .HasColumnName("quantity");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_order_items_order_id");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_order_items_product_id");

                    b.ToTable("OrderItems", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Domain.src.Entities.PaymentAggregate.Payment", b =>
                {
                    b.HasBaseType("Ecommerce.Domain.src.Shared.BaseEntity");

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric")
                        .HasColumnName("amount");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("payment_date");

                    b.Property<Guid>("PaymentMethodId")
                        .HasMaxLength(50)
                        .HasColumnType("uuid")
                        .HasColumnName("payment_method_id");

                    b.Property<int>("PaymentStatus")
                        .HasMaxLength(50)
                        .HasColumnType("integer")
                        .HasColumnName("payment_status");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_payments_order_id");

                    b.HasIndex("PaymentMethodId")
                        .HasDatabaseName("ix_payments_payment_method_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_payments_user_id");

                    b.ToTable("Payments", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Domain.src.Entities.ReviewAggregate.Review", b =>
                {
                    b.HasBaseType("Ecommerce.Domain.src.Shared.BaseEntity");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.Property<int>("Rating")
                        .HasColumnType("integer")
                        .HasColumnName("rating");

                    b.Property<DateTime>("ReviewDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("review_date");

                    b.Property<string>("ReviewText")
                        .HasColumnType("text")
                        .HasColumnName("review_text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_reviews_product_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_reviews_user_id");

                    b.ToTable("Reviews", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Domain.src.Entities.ShipmentAggregate.Shipment", b =>
                {
                    b.HasBaseType("Ecommerce.Domain.src.Shared.BaseEntity");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uuid")
                        .HasColumnName("address_id");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid")
                        .HasColumnName("order_id");

                    b.Property<DateTime>("ShipmentDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("shipment_date");

                    b.Property<int>("ShipmentStatus")
                        .HasColumnType("integer")
                        .HasColumnName("shipment_status");

                    b.Property<string>("TrackingNumber")
                        .HasColumnType("text")
                        .HasColumnName("tracking_number");

                    b.HasIndex("AddressId")
                        .HasDatabaseName("ix_shipments_address_id");

                    b.HasIndex("OrderId")
                        .HasDatabaseName("ix_shipments_order_id");

                    b.ToTable("Shipments", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Domain.src.Entities.UserAggregate.UserAddress", b =>
                {
                    b.HasBaseType("Ecommerce.Domain.src.Shared.BaseEntity");

                    b.Property<Guid>("AddressId")
                        .HasColumnType("uuid")
                        .HasColumnName("address_id");

                    b.Property<bool>("IsDefault")
                        .HasColumnType("boolean")
                        .HasColumnName("is_default");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasIndex("AddressId")
                        .HasDatabaseName("ix_user_addresses_address_id");

                    b.HasIndex("UserId")
                        .HasDatabaseName("ix_user_addresses_user_id");

                    b.ToTable("UserAddresses", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Domain.src.PaymentAggregate.PaymentMethod", b =>
                {
                    b.HasBaseType("Ecommerce.Domain.src.Shared.BaseEntity");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("card_number");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("expiry_date");

                    b.Property<string>("PaymentType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("payment_type");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)")
                        .HasColumnName("provider");

                    b.ToTable("PaymentMethods", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Domain.src.ProductAggregate.Product", b =>
                {
                    b.HasBaseType("Ecommerce.Domain.src.Shared.BaseEntity");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid")
                        .HasColumnName("category_id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("description");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("price");

                    b.Property<string>("ProductCode")
                        .HasMaxLength(20)
                        .HasColumnType("character varying(20)")
                        .HasColumnName("product_code");

                    b.Property<int>("Stock")
                        .HasColumnType("integer")
                        .HasColumnName("stock");

                    b.Property<string>("Title")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("title");

                    b.HasIndex("CategoryId")
                        .HasDatabaseName("ix_products_category_id");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Domain.src.ProductAggregate.ProductImage", b =>
                {
                    b.HasBaseType("Ecommerce.Domain.src.Shared.BaseEntity");

                    b.Property<string>("ImageText")
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("image_text");

                    b.Property<string>("ImageURL")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasColumnName("image_url");

                    b.Property<bool>("IsPrimary")
                        .HasColumnType("boolean")
                        .HasColumnName("is_primary");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid")
                        .HasColumnName("product_id");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_product_images_product_id");

                    b.ToTable("ProductImages", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Domain.src.UserAggregate.User", b =>
                {
                    b.HasBaseType("Ecommerce.Domain.src.Shared.BaseEntity");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("password");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<int>("Role")
                        .HasColumnType("integer")
                        .HasColumnName("role");

                    b.Property<byte[]>("Salt")
                        .IsRequired()
                        .HasColumnType("bytea")
                        .HasColumnName("salt");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("user_name");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("Ecommerce.Domain.src.AddressAggregate.Address", b =>
                {
                    b.HasOne("Ecommerce.Domain.src.Shared.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Ecommerce.Domain.src.AddressAggregate.Address", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_addresses_base_entity_id");
                });

            modelBuilder.Entity("Ecommerce.Domain.src.CategoryAggregate.Category", b =>
                {
                    b.HasOne("Ecommerce.Domain.src.Shared.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Ecommerce.Domain.src.CategoryAggregate.Category", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_categories_base_entity_id");
                });

            modelBuilder.Entity("Ecommerce.Domain.src.Entities.OrderAggregate.Order", b =>
                {
                    b.HasOne("Ecommerce.Domain.src.Shared.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Ecommerce.Domain.src.Entities.OrderAggregate.Order", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_base_entity_id");

                    b.HasOne("Ecommerce.Domain.src.AddressAggregate.Address", "Address")
                        .WithMany()
                        .HasForeignKey("ShippingAddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_addresses_shipping_address_id");

                    b.HasOne("Ecommerce.Domain.src.UserAggregate.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_orders_users_user_id");

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ecommerce.Domain.src.Entities.OrderAggregate.OrderItem", b =>
                {
                    b.HasOne("Ecommerce.Domain.src.Shared.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Ecommerce.Domain.src.Entities.OrderAggregate.OrderItem", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_items_base_entity_id");

                    b.HasOne("Ecommerce.Domain.src.Entities.OrderAggregate.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_items_orders_order_id");

                    b.HasOne("Ecommerce.Domain.src.ProductAggregate.Product", "Product")
                        .WithMany("OrderItems")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_order_items_products_product_id");

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ecommerce.Domain.src.Entities.PaymentAggregate.Payment", b =>
                {
                    b.HasOne("Ecommerce.Domain.src.Shared.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Ecommerce.Domain.src.Entities.PaymentAggregate.Payment", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_payments_base_entity_id");

                    b.HasOne("Ecommerce.Domain.src.Entities.OrderAggregate.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_payments_orders_order_id");

                    b.HasOne("Ecommerce.Domain.src.PaymentAggregate.PaymentMethod", "PaymentMethod")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_payments_payment_methods_payment_method_id");

                    b.HasOne("Ecommerce.Domain.src.UserAggregate.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_payments_users_user_id");

                    b.Navigation("Order");

                    b.Navigation("PaymentMethod");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ecommerce.Domain.src.Entities.ReviewAggregate.Review", b =>
                {
                    b.HasOne("Ecommerce.Domain.src.Shared.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Ecommerce.Domain.src.Entities.ReviewAggregate.Review", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_base_entity_id");

                    b.HasOne("Ecommerce.Domain.src.ProductAggregate.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_products_product_id");

                    b.HasOne("Ecommerce.Domain.src.UserAggregate.User", "User")
                        .WithMany("Reviews")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_reviews_users_user_id");

                    b.Navigation("Product");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ecommerce.Domain.src.Entities.ShipmentAggregate.Shipment", b =>
                {
                    b.HasOne("Ecommerce.Domain.src.AddressAggregate.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_shipments_addresses_address_id");

                    b.HasOne("Ecommerce.Domain.src.Shared.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Ecommerce.Domain.src.Entities.ShipmentAggregate.Shipment", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_shipments_base_entity_id");

                    b.HasOne("Ecommerce.Domain.src.Entities.OrderAggregate.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_shipments_orders_order_id");

                    b.Navigation("Address");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Ecommerce.Domain.src.Entities.UserAggregate.UserAddress", b =>
                {
                    b.HasOne("Ecommerce.Domain.src.AddressAggregate.Address", "Address")
                        .WithMany("UserAddresses")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_addresses_addresses_address_id");

                    b.HasOne("Ecommerce.Domain.src.Shared.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Ecommerce.Domain.src.Entities.UserAggregate.UserAddress", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_addresses_base_entity_id");

                    b.HasOne("Ecommerce.Domain.src.UserAggregate.User", "User")
                        .WithMany("UserAddresses")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_user_addresses_users_user_id");

                    b.Navigation("Address");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Ecommerce.Domain.src.PaymentAggregate.PaymentMethod", b =>
                {
                    b.HasOne("Ecommerce.Domain.src.Shared.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Ecommerce.Domain.src.PaymentAggregate.PaymentMethod", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_payment_methods_base_entity_id");
                });

            modelBuilder.Entity("Ecommerce.Domain.src.ProductAggregate.Product", b =>
                {
                    b.HasOne("Ecommerce.Domain.src.CategoryAggregate.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_products_categories_category_id");

                    b.HasOne("Ecommerce.Domain.src.Shared.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Ecommerce.Domain.src.ProductAggregate.Product", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_products_base_entity_id");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Ecommerce.Domain.src.ProductAggregate.ProductImage", b =>
                {
                    b.HasOne("Ecommerce.Domain.src.Shared.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Ecommerce.Domain.src.ProductAggregate.ProductImage", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_product_images_base_entity_id");

                    b.HasOne("Ecommerce.Domain.src.ProductAggregate.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_product_images_products_product_id");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Ecommerce.Domain.src.UserAggregate.User", b =>
                {
                    b.HasOne("Ecommerce.Domain.src.Shared.BaseEntity", null)
                        .WithOne()
                        .HasForeignKey("Ecommerce.Domain.src.UserAggregate.User", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_users_base_entity_id");
                });

            modelBuilder.Entity("Ecommerce.Domain.src.AddressAggregate.Address", b =>
                {
                    b.Navigation("UserAddresses");
                });

            modelBuilder.Entity("Ecommerce.Domain.src.CategoryAggregate.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("Ecommerce.Domain.src.Entities.OrderAggregate.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("Ecommerce.Domain.src.PaymentAggregate.PaymentMethod", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Ecommerce.Domain.src.ProductAggregate.Product", b =>
                {
                    b.Navigation("OrderItems");

                    b.Navigation("ProductImages");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Ecommerce.Domain.src.UserAggregate.User", b =>
                {
                    b.Navigation("Orders");

                    b.Navigation("Reviews");

                    b.Navigation("UserAddresses");
                });
#pragma warning restore 612, 618
        }
    }
}
