using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using stock_app_api.Models;

namespace stock_app_api.DataAccess;

public partial class StockAppContext : DbContext
{
    public StockAppContext()
    {
    }

    public StockAppContext(DbContextOptions<StockAppContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CoveredWarrant> CoveredWarrants { get; set; }

    public virtual DbSet<Derivative> Derivatives { get; set; }

    public virtual DbSet<EducationResource> EducationResources { get; set; }

    public virtual DbSet<Etf> Etfs { get; set; }

    public virtual DbSet<EtfHolding> EtfHoldings { get; set; }

    public virtual DbSet<EtfQuote> EtfQuotes { get; set; }

    public virtual DbSet<IndexConstituent> IndexConstituents { get; set; }

    public virtual DbSet<LinkedBankAccount> LinkedBankAccounts { get; set; }

    public virtual DbSet<MarketIndex> MarketIndices { get; set; }

    public virtual DbSet<Notification> Notifications { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Portfolio> Portfolios { get; set; }

    public virtual DbSet<Quote> Quotes { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserDevice> UserDevices { get; set; }

    public virtual DbSet<ViewQuote> ViewQuotes { get; set; }

    public virtual DbSet<WatchList> WatchLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CoveredWarrant>(entity =>
        {
            entity.HasKey(e => e.WarrantId).HasName("PK__covered___2BD1EED25666828F");

            entity.ToTable("covered_warrants");

            entity.Property(e => e.WarrantId).HasColumnName("warrant_id");
            entity.Property(e => e.Expiration).HasColumnName("expiration");
            entity.Property(e => e.IssueDate).HasColumnName("issue_date");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.StockId).HasColumnName("stock_id");
            entity.Property(e => e.StrikePrice)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("strike_price");
            entity.Property(e => e.WarrantType)
                .HasMaxLength(50)
                .HasColumnName("warrant_type");

            entity.HasOne(d => d.Stock).WithMany(p => p.CoveredWarrants)
                .HasForeignKey(d => d.StockId)
                .HasConstraintName("FK__covered_w__stock__4CA06362");
        });

        modelBuilder.Entity<Derivative>(entity =>
        {
            entity.HasKey(e => e.DerivativeId).HasName("PK__derivati__EF7FE46F83F840F2");

            entity.ToTable("derivatives");

            entity.Property(e => e.DerivativeId).HasColumnName("derivative_id");
            entity.Property(e => e.Change)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("change");
            entity.Property(e => e.ContractSize).HasColumnName("contract_size");
            entity.Property(e => e.ExpirationDate).HasColumnName("expiration_date");
            entity.Property(e => e.HighPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("high_price");
            entity.Property(e => e.LastPrice)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("last_price");
            entity.Property(e => e.LowPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("low_price");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.OpenInterest).HasColumnName("open_interest");
            entity.Property(e => e.OpenPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("open_price");
            entity.Property(e => e.PercentChange)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("percent_change");
            entity.Property(e => e.StockId).HasColumnName("stock_id");
            entity.Property(e => e.StrikePrice)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("strike_price");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("time_stamp");
            entity.Property(e => e.Volume).HasColumnName("volume");

            entity.HasOne(d => d.Stock).WithMany(p => p.Derivatives)
                .HasForeignKey(d => d.StockId)
                .HasConstraintName("FK__derivativ__stock__49C3F6B7");
        });

        modelBuilder.Entity<EducationResource>(entity =>
        {
            entity.HasKey(e => e.ResourceId).HasName("PK__educatio__4985FC7338891B24");

            entity.ToTable("education_resources");

            entity.Property(e => e.ResourceId).HasColumnName("resource_id");
            entity.Property(e => e.Category)
                .HasMaxLength(100)
                .HasColumnName("category");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.DatePublic)
                .HasColumnType("datetime")
                .HasColumnName("date_public");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Etf>(entity =>
        {
            entity.HasKey(e => e.EtfId).HasName("PK__etfs__917872164844A059");

            entity.ToTable("etfs");

            entity.HasIndex(e => e.Symbol, "UQ__etfs__DF7EEB81491A6E0E").IsUnique();

            entity.Property(e => e.EtfId).HasColumnName("etf_id");
            entity.Property(e => e.InceptionDate).HasColumnName("inception_date");
            entity.Property(e => e.ManagementCompany)
                .HasMaxLength(255)
                .HasColumnName("management_company");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Symbol)
                .HasMaxLength(50)
                .HasColumnName("symbol");
        });

        modelBuilder.Entity<EtfHolding>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__etf_hold__3213E83F8B991CA3");

            entity.ToTable("etf_holdings");

            entity.HasIndex(e => new { e.EtfId, e.StockId }, "UC_etf_stock").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EtfId).HasColumnName("etf_id");
            entity.Property(e => e.SharesHeld)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("shares_held");
            entity.Property(e => e.StockId).HasColumnName("stock_id");
            entity.Property(e => e.Weight)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("weight");

            entity.HasOne(d => d.Etf).WithMany(p => p.EtfHoldings)
                .HasForeignKey(d => d.EtfId)
                .HasConstraintName("FK__etf_holdi__etf_i__3493CFA7");

            entity.HasOne(d => d.Stock).WithMany(p => p.EtfHoldings)
                .HasForeignKey(d => d.StockId)
                .HasConstraintName("FK__etf_holdi__stock__3587F3E0");
        });

        modelBuilder.Entity<EtfQuote>(entity =>
        {
            entity.HasKey(e => e.QuoteId).HasName("PK__etf_quot__0D37DF0C81A92276");

            entity.ToTable("etf_quotes");

            entity.Property(e => e.QuoteId).HasColumnName("quote_id");
            entity.Property(e => e.Change)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("change");
            entity.Property(e => e.EtfId).HasColumnName("etf_id");
            entity.Property(e => e.PercentChange)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("percent_change");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("time_stamp");
            entity.Property(e => e.TotalVolume).HasColumnName("total_volume");

            entity.HasOne(d => d.Etf).WithMany(p => p.EtfQuotes)
                .HasForeignKey(d => d.EtfId)
                .HasConstraintName("FK__etf_quote__etf_i__0F624AF8");
        });

        modelBuilder.Entity<IndexConstituent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__index_co__3213E83FC1715FBD");

            entity.ToTable("index_constituent");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IndexId).HasColumnName("index_id");
            entity.Property(e => e.StockId).HasColumnName("stock_id");

            entity.HasOne(d => d.Index).WithMany(p => p.IndexConstituents)
                .HasForeignKey(d => d.IndexId)
                .HasConstraintName("FK__index_con__index__30C33EC3");

            entity.HasOne(d => d.Stock).WithMany(p => p.IndexConstituents)
                .HasForeignKey(d => d.StockId)
                .HasConstraintName("FK__index_con__stock__31B762FC");
        });

        modelBuilder.Entity<LinkedBankAccount>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__linked_b__46A222CD5E56050A");

            entity.ToTable("linked_bank_accounts");

            entity.Property(e => e.AccountId).HasColumnName("account_id");
            entity.Property(e => e.AccountNumber)
                .HasMaxLength(50)
                .HasColumnName("account_number");
            entity.Property(e => e.AccountType)
                .HasMaxLength(50)
                .HasColumnName("account_type");
            entity.Property(e => e.BankName)
                .HasMaxLength(255)
                .HasColumnName("bank_name");
            entity.Property(e => e.RoutingNumber)
                .HasMaxLength(50)
                .HasColumnName("routing_number");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.LinkedBankAccounts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__linked_ba__user___7E37BEF6");
        });

        modelBuilder.Entity<MarketIndex>(entity =>
        {
            entity.HasKey(e => e.IndexId).HasName("PK__market_i__9D4F3187EFC94F25");

            entity.ToTable("market_indices");

            entity.HasIndex(e => e.Symbol, "UQ__market_i__DF7EEB8167750D5E").IsUnique();

            entity.Property(e => e.IndexId).HasColumnName("index_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Symbol)
                .HasMaxLength(50)
                .HasColumnName("symbol");
        });

        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(e => e.NotificationId).HasName("PK__notifica__E059842FEE48369C");

            entity.ToTable("notifications");

            entity.Property(e => e.NotificationId).HasColumnName("notification_id");
            entity.Property(e => e.Content)
                .HasColumnType("text")
                .HasColumnName("content");
            entity.Property(e => e.CreatedAt)
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.IsRead)
                .HasDefaultValue(false)
                .HasColumnName("is_read");
            entity.Property(e => e.NotificationType)
                .HasMaxLength(50)
                .HasColumnName("notification_type");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.Notifications)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__notificat__user___787EE5A0");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__orders__4659622904136CBC");

            entity.ToTable("orders", tb => tb.HasTrigger("AfterInsertOrder"));

            entity.Property(e => e.OrderId).HasColumnName("order_id");
            entity.Property(e => e.Direction)
                .HasMaxLength(20)
                .HasColumnName("direction");
            entity.Property(e => e.OrderDate)
                .HasColumnType("datetime")
                .HasColumnName("order_date");
            entity.Property(e => e.OrderType)
                .HasMaxLength(20)
                .HasColumnName("order_type");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .HasColumnName("status");
            entity.Property(e => e.StockId).HasColumnName("stock_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Stock).WithMany(p => p.Orders)
                .HasForeignKey(d => d.StockId)
                .HasConstraintName("FK__orders__stock_id__74AE54BC");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__orders__user_id__73BA3083");
        });

        modelBuilder.Entity<Portfolio>(entity =>
        {
            entity.HasKey(e => e.PortfolioId).HasName("PK__portfoli__42EE526FBCC7E539");

            entity.ToTable("portfolios");

            entity.HasIndex(e => new { e.UserId, e.StockId }, "UQ_Portfolios").IsUnique();

            entity.Property(e => e.PortfolioId).HasColumnName("portfolio_id");
            entity.Property(e => e.PurchaseDate)
                .HasColumnType("datetime")
                .HasColumnName("purchase_date");
            entity.Property(e => e.PurchasePrice)
                .HasColumnType("decimal(18, 4)")
                .HasColumnName("purchase_price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");
            entity.Property(e => e.StockId).HasColumnName("stock_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Stock).WithMany(p => p.Portfolios)
                .HasForeignKey(d => d.StockId)
                .HasConstraintName("FK__portfolio__stock__2A164134");

            entity.HasOne(d => d.User).WithMany(p => p.Portfolios)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__portfolio__user___29221CFB");
        });

        modelBuilder.Entity<Quote>(entity =>
        {
            entity.HasKey(e => e.QuoteId).HasName("PK__quotes__0D37DF0C8D376866");

            entity.ToTable("quotes");

            entity.Property(e => e.QuoteId).HasColumnName("quote_id");
            entity.Property(e => e.Change)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("change");
            entity.Property(e => e.PercentChange)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("percent_change");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.StockId).HasColumnName("stock_id");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("time_stamp");
            entity.Property(e => e.Volume).HasColumnName("volume");

            entity.HasOne(d => d.Stock).WithMany(p => p.Quotes)
                .HasForeignKey(d => d.StockId)
                .HasConstraintName("FK__quotes__stock_id__412EB0B6");
        });

        modelBuilder.Entity<Stock>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PK__stocks__E866686219E58FA0");

            entity.ToTable("stocks");

            entity.Property(e => e.StockId).HasColumnName("stock_id");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .HasColumnName("company_name");
            entity.Property(e => e.Industry)
                .HasMaxLength(200)
                .HasColumnName("industry");
            entity.Property(e => e.IndustryEn)
                .HasMaxLength(200)
                .HasColumnName("industry_en");
            entity.Property(e => e.MarketCap)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("market_cap");
            entity.Property(e => e.Rank)
                .HasDefaultValue(0)
                .HasColumnName("rank");
            entity.Property(e => e.RankSource)
                .HasMaxLength(255)
                .HasColumnName("rank_source");
            entity.Property(e => e.Reason)
                .HasMaxLength(255)
                .HasColumnName("reason");
            entity.Property(e => e.Sector)
                .HasMaxLength(255)
                .HasColumnName("sector");
            entity.Property(e => e.SectorEn)
                .HasMaxLength(200)
                .HasColumnName("sector_en");
            entity.Property(e => e.StockType)
                .HasMaxLength(50)
                .HasColumnName("stock_type");
            entity.Property(e => e.Symbol)
                .HasMaxLength(10)
                .HasColumnName("symbol");
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__transact__85C600AFFC76EE4B");

            entity.ToTable("transactions");

            entity.Property(e => e.TransactionId).HasColumnName("transaction_id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.LinkedAccountId).HasColumnName("linked_account_id");
            entity.Property(e => e.TransactionDate)
                .HasColumnType("datetime")
                .HasColumnName("transaction_date");
            entity.Property(e => e.TransactionType)
                .HasMaxLength(50)
                .HasColumnName("transaction_type");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.LinkedAccount).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.LinkedAccountId)
                .HasConstraintName("FK__transacti__linke__02084FDA");

            entity.HasOne(d => d.User).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__transacti__user___01142BA1");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__users__B9BE370FBE174D24");

            entity.ToTable("users");

            entity.HasIndex(e => e.UserName, "UQ__users__7C9273C4B3974A3A").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__users__AB6E61646090D873").IsUnique();

            entity.Property(e => e.Role).HasColumnName("role");
            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Country)
                .HasMaxLength(100)
                .HasColumnName("country");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("full_name");
            entity.Property(e => e.HashedPassword)
                .HasMaxLength(200)
                .HasColumnName("hashed_password");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .HasColumnName("phone");
            entity.Property(e => e.UserName)
                .HasMaxLength(100)
                .HasColumnName("user_name");
        });

        modelBuilder.Entity<UserDevice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__user_dev__3213E83F570FCEB1");

            entity.ToTable("user_devices");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DeviceId)
                .HasMaxLength(255)
                .HasColumnName("device_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.User).WithMany(p => p.UserDevices)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__user_devi__user___3B75D760");
        });

        modelBuilder.Entity<ViewQuote>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("view_quotes");

            entity.Property(e => e.CompanyName)
                .HasMaxLength(255)
                .HasColumnName("company_name");
            entity.Property(e => e.IndexName)
                .HasMaxLength(255)
                .HasColumnName("index_name");
            entity.Property(e => e.IndexSymbol)
                .HasMaxLength(50)
                .HasColumnName("index_symbol");
            entity.Property(e => e.IndustryEn)
                .HasMaxLength(200)
                .HasColumnName("industry_en");
            entity.Property(e => e.MarketCap)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("market_cap");
            entity.Property(e => e.PercentChange)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("percent_change");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.QuoteId).HasColumnName("quote_id");
            entity.Property(e => e.SectorEn)
                .HasMaxLength(200)
                .HasColumnName("sector_en");
            entity.Property(e => e.StockType)
                .HasMaxLength(50)
                .HasColumnName("stock_type");
            entity.Property(e => e.Symbol)
                .HasMaxLength(10)
                .HasColumnName("symbol");
            entity.Property(e => e.TimeStamp)
                .HasColumnType("datetime")
                .HasColumnName("time_stamp");
            entity.Property(e => e.Volume).HasColumnName("volume");
        });

        modelBuilder.Entity<WatchList>(entity =>
        {
            entity.HasKey(e => e.WatchId).HasName("PK__watch_li__E83F8077C6945194");

            entity.ToTable("watch_lists");

            entity.HasIndex(e => new { e.UserId, e.StockId }, "UC_watch_lists_users_stocks").IsUnique();

            entity.Property(e => e.WatchId).HasColumnName("watch_id");
            entity.Property(e => e.StockId).HasColumnName("stock_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Stock).WithMany(p => p.WatchLists)
                .HasForeignKey(d => d.StockId)
                .HasConstraintName("FK__watch_lis__stock__2DE6D218");

            entity.HasOne(d => d.User).WithMany(p => p.WatchLists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__watch_lis__user___2CF2ADDF");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
