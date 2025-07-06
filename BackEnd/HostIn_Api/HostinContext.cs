using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HostIn_Api;

public partial class HostinContext : DbContext
{
    public HostinContext()
    {
    }

    public HostinContext(DbContextOptions<HostinContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TbBanco> TbBancos { get; set; }

    public virtual DbSet<TbBloco> TbBlocos { get; set; }

    public virtual DbSet<TbCaixa> TbCaixas { get; set; }

    public virtual DbSet<TbCategoria> TbCategorias { get; set; }

    public virtual DbSet<TbCidade> TbCidades { get; set; }

    public virtual DbSet<TbCompra> TbCompras { get; set; }

    public virtual DbSet<TbComprasIten> TbComprasItens { get; set; }

    public virtual DbSet<TbComunidade> TbComunidades { get; set; }

    public virtual DbSet<TbConta> TbContas { get; set; }

    public virtual DbSet<TbContasPagar> TbContasPagars { get; set; }

    public virtual DbSet<TbContasPagarIten> TbContasPagarItens { get; set; }

    public virtual DbSet<TbContasReceber> TbContasRecebers { get; set; }

    public virtual DbSet<TbContasReceberIten> TbContasReceberItens { get; set; }

    public virtual DbSet<TbContrato> TbContratos { get; set; }

    public virtual DbSet<TbCupon> TbCupons { get; set; }

    public virtual DbSet<TbEmpresa> TbEmpresas { get; set; }

    public virtual DbSet<TbEvento> TbEventos { get; set; }

    public virtual DbSet<TbEventoDespesa> TbEventoDespesas { get; set; }

    public virtual DbSet<TbEventoPessoa> TbEventoPessoas { get; set; }

    public virtual DbSet<TbEventoQuarto> TbEventoQuartos { get; set; }

    public virtual DbSet<TbGavetum> TbGaveta { get; set; }

    public virtual DbSet<TbHospede> TbHospedes { get; set; }

    public virtual DbSet<TbLancamento> TbLancamentos { get; set; }

    public virtual DbSet<TbModeloContrato> TbModeloContratos { get; set; }

    public virtual DbSet<TbModulo> TbModulos { get; set; }

    public virtual DbSet<TbMovimentoCaixa> TbMovimentoCaixas { get; set; }

    public virtual DbSet<TbMovimentoContaCorrente> TbMovimentoContaCorrentes { get; set; }

    public virtual DbSet<TbMovimentoEstoque> TbMovimentoEstoques { get; set; }

    public virtual DbSet<TbMovimentoInvestimento> TbMovimentoInvestimentos { get; set; }

    public virtual DbSet<TbParoquium> TbParoquia { get; set; }

    public virtual DbSet<TbParticipante> TbParticipantes { get; set; }

    public virtual DbSet<TbParticipantesCupon> TbParticipantesCupons { get; set; }

    public virtual DbSet<TbPermissao> TbPermissaos { get; set; }

    public virtual DbSet<TbPessoa> TbPessoas { get; set; }

    public virtual DbSet<TbPlanoConta> TbPlanoContas { get; set; }

    public virtual DbSet<TbPremio> TbPremios { get; set; }

    public virtual DbSet<TbProduto> TbProdutos { get; set; }

    public virtual DbSet<TbPromocao> TbPromocaos { get; set; }

    public virtual DbSet<TbQuarto> TbQuartos { get; set; }

    public virtual DbSet<TbQuartoPessoa> TbQuartoPessoas { get; set; }

    public virtual DbSet<TbServico> TbServicos { get; set; }

    public virtual DbSet<TbSorteio> TbSorteios { get; set; }

    public virtual DbSet<TbTela> TbTelas { get; set; }

    public virtual DbSet<TbUsuario> TbUsuarios { get; set; }

    public virtual DbSet<TbUsuarioModulo> TbUsuarioModulos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Initial Catalog=Hostin;Integrated Security=true;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbBanco>(entity =>
        {
            entity.HasKey(e => e.BanCodigo).HasName("PK__Tb_Banco__96A5870E9DBC5B1F");

            entity.ToTable("Tb_Bancos");

            entity.HasIndex(e => e.BanCodigo, "UQ__Tb_Banco__96A5870F145F842F").IsUnique();

            entity.Property(e => e.BanDescricao).HasMaxLength(50);
            entity.Property(e => e.BanDigito).HasMaxLength(2);
            entity.Property(e => e.BanLogo).HasColumnType("text");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbBancos)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_Bancos_Tb_Empresa");
        });

        modelBuilder.Entity<TbBloco>(entity =>
        {
            entity.HasKey(e => e.BloCodigo).HasName("PK__Tb_Bloco__9CBD088008A994ED");

            entity.ToTable("Tb_Blocos");

            entity.HasIndex(e => e.BloCodigo, "UQ__Tb_Bloco__9CBD08819256E180").IsUnique();

            entity.Property(e => e.BloNome).HasMaxLength(100);
        });

        modelBuilder.Entity<TbCaixa>(entity =>
        {
            entity.HasKey(e => e.CaiCodigo).HasName("PK__Tb_Caixa__D2C1E5D8A1060C55");

            entity.ToTable("Tb_Caixa");

            entity.HasIndex(e => e.CaiCodigo, "UQ__Tb_Caixa__D2C1E5D982A2152D").IsUnique();

            entity.Property(e => e.CaiDataAbertura).HasColumnType("datetime");
            entity.Property(e => e.CaiDataFechamento).HasColumnType("datetime");
            entity.Property(e => e.CaiSaldoFechamento).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CaiStatus).HasMaxLength(1);

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbCaixas)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_Caixa_Tb_Empresa");
        });

        modelBuilder.Entity<TbCategoria>(entity =>
        {
            entity.HasKey(e => e.CatCodigo).HasName("PK__Tb_Categ__16498BD9E670855B");

            entity.ToTable("Tb_Categorias");

            entity.HasIndex(e => e.CatCodigo, "UQ__Tb_Categ__16498BD861ED0D0C").IsUnique();

            entity.Property(e => e.CatNome).HasMaxLength(100);

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbCategoria)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_Categorias_Tb_Empresa");
        });

        modelBuilder.Entity<TbCidade>(entity =>
        {
            entity.HasKey(e => e.CidCodigo).HasName("PK__Tb_Cidad__F0B95DFFF995A31E");

            entity.ToTable("Tb_Cidades");

            entity.HasIndex(e => e.CidCodigo, "UQ__Tb_Cidad__F0B95DFE17FA4B71").IsUnique();

            entity.Property(e => e.CidNome).HasMaxLength(50);
            entity.Property(e => e.CidUf)
                .HasMaxLength(2)
                .HasColumnName("CidUF");
        });

        modelBuilder.Entity<TbCompra>(entity =>
        {
            entity.HasKey(e => e.ComCodigo).HasName("PK__Tb_Compr__F21E9844CC68ED43");

            entity.ToTable("Tb_Compras");

            entity.HasIndex(e => e.ComCodigo, "UQ__Tb_Compr__F21E984500B541B9").IsUnique();

            entity.Property(e => e.ComArquivo).HasMaxLength(255);
            entity.Property(e => e.ComJustificativa).HasColumnType("text");
            entity.Property(e => e.ComObservacao).HasColumnType("text");
            entity.Property(e => e.ComStatus).HasMaxLength(1);

            entity.HasOne(d => d.AutoriCodigoNavigation).WithMany(p => p.TbCompraAutoriCodigoNavigations)
                .HasForeignKey(d => d.AutoriCodigo)
                .HasConstraintName("FK_Tb_Compras_Autorizador");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbCompras)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_Compras_Tb_Empresa");

            entity.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbCompras)
                .HasForeignKey(d => d.PesCodigo)
                .HasConstraintName("FK_Tb_Compras_Tb_ContasPagar");

            entity.HasOne(d => d.SoliciCodigoNavigation).WithMany(p => p.TbCompraSoliciCodigoNavigations)
                .HasForeignKey(d => d.SoliciCodigo)
                .HasConstraintName("FK_Tb_Compras_Solicitante");
        });

        modelBuilder.Entity<TbComprasIten>(entity =>
        {
            entity.HasKey(e => e.CmiCodigo).HasName("PK__Tb_Compr__9D6BC121B6CEC669");

            entity.ToTable("Tb_ComprasItens");

            entity.HasIndex(e => e.CmiCodigo, "UQ__Tb_Compr__9D6BC120C42E23E5").IsUnique();

            entity.Property(e => e.CmiValor).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CmiValorTotal).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.ComCodigoNavigation).WithMany(p => p.TbComprasItens)
                .HasForeignKey(d => d.ComCodigo)
                .HasConstraintName("FK_Tb_ComprasItens_Tb_Compras");

            entity.HasOne(d => d.ProCodigoNavigation).WithMany(p => p.TbComprasItens)
                .HasForeignKey(d => d.ProCodigo)
                .HasConstraintName("FK_Tb_ComprasItens_Tb_Produtos");
        });

        modelBuilder.Entity<TbComunidade>(entity =>
        {
            entity.HasKey(e => e.ComCodigo).HasName("PK__Tb_Comun__F21E98444B3B9463");

            entity.ToTable("Tb_Comunidades");

            entity.HasIndex(e => e.ComCodigo, "UQ__Tb_Comun__F21E98451DAE2F22").IsUnique();

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbComunidades)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_Comunidades_Tb_Empresa");

            entity.HasOne(d => d.PrqCodigoNavigation).WithMany(p => p.TbComunidades)
                .HasForeignKey(d => d.PrqCodigo)
                .HasConstraintName("FK_Tb_Comunidades_Tb_Paroquia");
        });

        modelBuilder.Entity<TbConta>(entity =>
        {
            entity.HasKey(e => e.CntCodigo).HasName("PK__Tb_Conta__51AA3241D10C7C5A");

            entity.ToTable("Tb_Contas");

            entity.HasIndex(e => e.CntCodigo, "UQ__Tb_Conta__51AA3240ED817BC9").IsUnique();

            entity.Property(e => e.CntAgencia).HasMaxLength(10);
            entity.Property(e => e.CntAgenciaDigito).HasMaxLength(3);
            entity.Property(e => e.CntConta).HasMaxLength(15);
            entity.Property(e => e.CntContaDigito).HasMaxLength(3);
            entity.Property(e => e.CntNomeAgencia).HasMaxLength(20);
            entity.Property(e => e.CntTipoConta).HasMaxLength(1);
            entity.Property(e => e.CntTitular).HasMaxLength(50);

            entity.HasOne(d => d.BanCodigoNavigation).WithMany(p => p.TbConta)
                .HasForeignKey(d => d.BanCodigo)
                .HasConstraintName("FK_Tb_Contas_Tb_Bancos");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbConta)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_Contas_Tb_Empresa");
        });

        modelBuilder.Entity<TbContasPagar>(entity =>
        {
            entity.HasKey(e => e.CtpCodigo).HasName("PK__Tb_Conta__D06E6BB8DB55A6C2");

            entity.ToTable("Tb_ContasPagar");

            entity.HasIndex(e => e.CtpCodigo, "UQ__Tb_Conta__D06E6BB9CC24BC14").IsUnique();

            entity.Property(e => e.CtpDescricao).HasMaxLength(255);
            entity.Property(e => e.CtpValor).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbContasPagars)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_ContasPagar_Tb_Empresa");

            entity.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbContasPagars)
                .HasForeignKey(d => d.PesCodigo)
                .HasConstraintName("FK_Tb_ContasPagar_Tb_Pessoas");

            entity.HasOne(d => d.PlcCodigoNavigation).WithMany(p => p.TbContasPagars)
                .HasForeignKey(d => d.PlcCodigo)
                .HasConstraintName("FK_Tb_ContasPagar_Tb_PlanoContas");
        });

        modelBuilder.Entity<TbContasPagarIten>(entity =>
        {
            entity.HasKey(e => e.CpiCodigo);

            entity.ToTable("Tb_ContasPagarItens");

            entity.Property(e => e.CpiDesconto).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CpiValor).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.CtpCodigoNavigation).WithMany(p => p.TbContasPagarItens)
                .HasForeignKey(d => d.CtpCodigo)
                .HasConstraintName("FK_Tb_ContasPagarItens_Tb_ContasPagar");
        });

        modelBuilder.Entity<TbContasReceber>(entity =>
        {
            entity.HasKey(e => e.CtrCodigo);

            entity.ToTable("Tb_ContasReceber");

            entity.Property(e => e.CtrDescricao).HasColumnType("text");
            entity.Property(e => e.CtrValor).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbContasRecebers)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_ContasReceber_Tb_Empresa");

            entity.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbContasRecebers)
                .HasForeignKey(d => d.PesCodigo)
                .HasConstraintName("FK_Tb_ContasReceber_Tb_Pessoas");

            entity.HasOne(d => d.PlcCodigoNavigation).WithMany(p => p.TbContasRecebers)
                .HasForeignKey(d => d.PlcCodigo)
                .HasConstraintName("FK_Tb_ContasReceber_Tb_PlanoContas");
        });

        modelBuilder.Entity<TbContasReceberIten>(entity =>
        {
            entity.HasKey(e => e.CriCodigo);

            entity.ToTable("Tb_ContasReceberItens");

            entity.Property(e => e.CriDesconto).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.CriValor).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.CtrCodigoNavigation).WithMany(p => p.TbContasReceberItens)
                .HasForeignKey(d => d.CtrCodigo)
                .HasConstraintName("FK_Tb_ContasReceberItens_Tb_ContasReceber");
        });

        modelBuilder.Entity<TbContrato>(entity =>
        {
            entity.HasKey(e => e.CntCodigo);

            entity.ToTable("Tb_Contrato");

            entity.Property(e => e.CntArquivo).HasMaxLength(255);
            entity.Property(e => e.CntObservacao).HasColumnType("text");
            entity.Property(e => e.CntValor).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbContratos)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_Contrato_Tb_Empresa");

            entity.HasOne(d => d.MctCodigoNavigation).WithMany(p => p.TbContratos)
                .HasForeignKey(d => d.MctCodigo)
                .HasConstraintName("FK_Tb_Contrato_Tb_ModeloContratos");

            entity.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbContratos)
                .HasForeignKey(d => d.PesCodigo)
                .HasConstraintName("FK_Tb_Contrato_Tb_Pessoas");
        });

        modelBuilder.Entity<TbCupon>(entity =>
        {
            entity.HasKey(e => e.CupCodigo);

            entity.ToTable("Tb_Cupons");

            entity.Property(e => e.CupNumero).HasMaxLength(50);

            entity.HasOne(d => d.ParCodigoNavigation).WithMany(p => p.TbCupons)
                .HasForeignKey(d => d.ParCodigo)
                .HasConstraintName("FK_Tb_Cupons_Tb_Participantes");

            entity.HasOne(d => d.PrmCodigoNavigation).WithMany(p => p.TbCupons)
                .HasForeignKey(d => d.PrmCodigo)
                .HasConstraintName("FK_Tb_Cupons_Tb_Promocao");
        });

        modelBuilder.Entity<TbEmpresa>(entity =>
        {
            entity.HasKey(e => e.EmpCodigo);

            entity.ToTable("Tb_Empresa");

            entity.HasIndex(e => e.EmpCodigo, "Tb_Empresa_index_0");

            entity.HasIndex(e => e.EmpCodigo, "UQ__Tb_Empre__22C597B821DA9E26").IsUnique();

            entity.Property(e => e.EmpCidade).HasMaxLength(20);
            entity.Property(e => e.EmpCnpj).HasColumnName("EmpCNPJ");
            entity.Property(e => e.EmpEstado).HasMaxLength(2);
            entity.Property(e => e.EmpNome).HasMaxLength(150);
        });

        modelBuilder.Entity<TbEvento>(entity =>
        {
            entity.HasKey(e => e.EveCodigo);

            entity.ToTable("Tb_Eventos");

            entity.HasIndex(e => e.EveCodigo, "UQ__Tb_Event__0169913174BE3E37").IsUnique();

            entity.Property(e => e.EveDataFim).HasColumnType("datetime");
            entity.Property(e => e.EveDataInicio).HasColumnType("datetime");
            entity.Property(e => e.EveNome).HasMaxLength(100);
            entity.Property(e => e.EveObservacao).HasColumnType("text");
            entity.Property(e => e.EveTipoCobranca).HasMaxLength(1);
            entity.Property(e => e.EveValor).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbEventos)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_Eventos_Tb_Empresa");
        });

        modelBuilder.Entity<TbEventoDespesa>(entity =>
        {
            entity.HasKey(e => e.EdpCodigo).HasName("PK__Tb_Event__EC3B63A5BC4AFD01");

            entity.ToTable("Tb_EventoDespesa");

            entity.HasIndex(e => e.EdpCodigo, "UQ__Tb_Event__EC3B63A4F7896E92").IsUnique();

            entity.Property(e => e.EdpTipoDespesa).HasMaxLength(1);
            entity.Property(e => e.EdpValor).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.EveCodigoNavigation).WithMany(p => p.TbEventoDespesas)
                .HasForeignKey(d => d.EveCodigo)
                .HasConstraintName("FK_Tb_EventoDespesa_Tb_Eventos");

            entity.HasOne(d => d.ProCodigoNavigation).WithMany(p => p.TbEventoDespesas)
                .HasForeignKey(d => d.ProCodigo)
                .HasConstraintName("FK_Tb_EventoDespesa_Tb_Produtos");

            entity.HasOne(d => d.SerCodigoNavigation).WithMany(p => p.TbEventoDespesas)
                .HasForeignKey(d => d.SerCodigo)
                .HasConstraintName("FK_Tb_EventoDespesa_Tb_Servicos");
        });

        modelBuilder.Entity<TbEventoPessoa>(entity =>
        {
            entity.HasKey(e => e.EvpCodigo);

            entity.ToTable("Tb_EventoPessoas");

            entity.HasOne(d => d.EveCodigoNavigation).WithMany(p => p.TbEventoPessoas)
                .HasForeignKey(d => d.EveCodigo)
                .HasConstraintName("FK_Tb_EventoPessoas_Tb_Eventos");

            entity.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbEventoPessoas)
                .HasForeignKey(d => d.PesCodigo)
                .HasConstraintName("FK_Tb_EventoPessoas_Tb_Pessoas");
        });

        modelBuilder.Entity<TbEventoQuarto>(entity =>
        {
            entity.HasKey(e => e.EvqCodigo).HasName("PK__Tb_Event__FB1F98932DE385D6");

            entity.ToTable("Tb_EventoQuartos");

            entity.HasOne(d => d.EveCodigoNavigation).WithMany(p => p.TbEventoQuartos)
                .HasForeignKey(d => d.EveCodigo)
                .HasConstraintName("FK_Tb_EventoQuartos_Tb_Eventos");

            entity.HasOne(d => d.QuaCodigoNavigation).WithMany(p => p.TbEventoQuartos)
                .HasForeignKey(d => d.QuaCodigo)
                .HasConstraintName("FK_Tb_EventoQuartos_Tb_Quartos");
        });

        modelBuilder.Entity<TbGavetum>(entity =>
        {
            entity.HasKey(e => e.GavCodigo);

            entity.ToTable("Tb_Gaveta");

            entity.Property(e => e.GavConciliado).HasMaxLength(1);
            entity.Property(e => e.GavDescricao).HasMaxLength(255);
            entity.Property(e => e.GavObservacao).HasColumnType("text");
            entity.Property(e => e.GavTipo).HasMaxLength(1);
            entity.Property(e => e.GavTipoMovimento).HasMaxLength(2);
            entity.Property(e => e.GavValor).HasColumnType("numeric(18, 0)");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbGaveta)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_Gaveta_Tb_Empresa");
        });

        modelBuilder.Entity<TbHospede>(entity =>
        {
            entity.HasKey(e => e.HosCodigo);

            entity.ToTable("Tb_Hospedes");

            entity.Property(e => e.HosCatequista)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.HosCpf).HasColumnName("HosCPF");
            entity.Property(e => e.HosGenero).HasMaxLength(1);
            entity.Property(e => e.HosNome).HasMaxLength(100);
            entity.Property(e => e.HosObservacao).HasColumnType("text");
            entity.Property(e => e.HosResponsavel)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.HosSalmista)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.HosTelefone).HasMaxLength(13);

            entity.HasOne(d => d.ComCodigoNavigation).WithMany(p => p.TbHospedes)
                .HasForeignKey(d => d.ComCodigo)
                .HasConstraintName("FK_Tb_Hospedes_Tb_Comunidades");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbHospedes)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_Hospedes_Tb_Empresa");
        });

        modelBuilder.Entity<TbLancamento>(entity =>
        {
            entity.HasKey(e => e.LncCodigo);

            entity.ToTable("Tb_Lancamentos");

            entity.Property(e => e.LncDescricao).HasColumnType("text");
            entity.Property(e => e.LncTipoPeriodo).HasMaxLength(1);
            entity.Property(e => e.LncValor).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbLancamentos)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_Lancamentos_Tb_Empresa");

            entity.HasOne(d => d.PesCodigoNavigation).WithMany(p => p.TbLancamentos)
                .HasForeignKey(d => d.PesCodigo)
                .HasConstraintName("FK_Tb_Lancamentos_Tb_Pessoas");

            entity.HasOne(d => d.PlcCodigoNavigation).WithMany(p => p.TbLancamentos)
                .HasForeignKey(d => d.PlcCodigo)
                .HasConstraintName("FK_Tb_Lancamentos_Tb_PlanoContas");
        });

        modelBuilder.Entity<TbModeloContrato>(entity =>
        {
            entity.HasKey(e => e.MctCodigo);

            entity.ToTable("Tb_ModeloContratos");

            entity.HasIndex(e => e.MctCodigo, "UQ__Tb_Model__40BC36EE556CACA1").IsUnique();

            entity.Property(e => e.MctConteudo).HasColumnType("text");
            entity.Property(e => e.MctNome).HasMaxLength(255);

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbModeloContratos)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_ModeloContratos_Tb_Empresa");
        });

        modelBuilder.Entity<TbModulo>(entity =>
        {
            entity.HasKey(e => e.ModCodigo);

            entity.ToTable("Tb_Modulo");

            entity.Property(e => e.ModNome).HasMaxLength(255);
        });

        modelBuilder.Entity<TbMovimentoCaixa>(entity =>
        {
            entity.HasKey(e => e.McxCodigo).HasName("PK__Tb_Movim__5DD3ACD013E281F4");

            entity.ToTable("Tb_MovimentoCaixa");

            entity.HasIndex(e => e.McxCodigo, "UQ__Tb_Movim__5DD3ACD1C6215B5D").IsUnique();

            entity.Property(e => e.McxData).HasColumnType("datetime");
            entity.Property(e => e.McxDescricao).HasColumnType("text");
            entity.Property(e => e.McxFormaPagamento).HasMaxLength(10);
            entity.Property(e => e.McxTipo).HasMaxLength(1);
            entity.Property(e => e.McxValor).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.CaiCodigoNavigation).WithMany(p => p.TbMovimentoCaixas)
                .HasForeignKey(d => d.CaiCodigo)
                .HasConstraintName("FK_Tb_MovimentoCaixa_Tb_Caixa");
        });

        modelBuilder.Entity<TbMovimentoContaCorrente>(entity =>
        {
            entity.HasKey(e => e.MccCodigo).HasName("PK__Tb_Movim__2E1F527388616CFC");

            entity.ToTable("Tb_MovimentoContaCorrente");

            entity.HasIndex(e => e.MccCodigo, "UQ__Tb_Movim__2E1F527280DCA2C6").IsUnique();

            entity.Property(e => e.MccDescricao).HasMaxLength(255);
            entity.Property(e => e.MccDocumento).HasMaxLength(255);
            entity.Property(e => e.MccTipo).HasMaxLength(1);
            entity.Property(e => e.MccValor).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.CntCodigoNavigation).WithMany(p => p.TbMovimentoContaCorrentes)
                .HasForeignKey(d => d.CntCodigo)
                .HasConstraintName("FK_Tb_MovimentoContaCorrente_Tb_Contas");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbMovimentoContaCorrentes)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_MovimentoContaCorrente_Tb_Empresa");
        });

        modelBuilder.Entity<TbMovimentoEstoque>(entity =>
        {
            entity.HasKey(e => e.MovCodigo).HasName("PK__Tb_Movim__74474D54C575C0C2");

            entity.ToTable("Tb_MovimentoEstoque");

            entity.HasIndex(e => e.MovCodigo, "UQ__Tb_Movim__74474D558B28A6B3").IsUnique();

            entity.Property(e => e.MovObservacao).HasColumnType("text");
            entity.Property(e => e.MovTipo).HasMaxLength(1);

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbMovimentoEstoques)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_MovimentoEstoque_Tb_Empresa");

            entity.HasOne(d => d.ProCodigoNavigation).WithMany(p => p.TbMovimentoEstoques)
                .HasForeignKey(d => d.ProCodigo)
                .HasConstraintName("FK_Tb_MovimentoEstoque_Tb_Produtos");

            entity.HasOne(d => d.UsuCodigoNavigation).WithMany(p => p.TbMovimentoEstoques)
                .HasForeignKey(d => d.UsuCodigo)
                .HasConstraintName("FK_Tb_MovimentoEstoque_Tb_Usuarios");
        });

        modelBuilder.Entity<TbMovimentoInvestimento>(entity =>
        {
            entity.HasKey(e => e.MinCodigo).HasName("PK__Tb_Movim__3A282FAEF81F7689");

            entity.ToTable("Tb_MovimentoInvestimento");

            entity.HasIndex(e => e.MinCodigo, "UQ__Tb_Movim__3A282FAFB7C583BF").IsUnique();

            entity.Property(e => e.MinDescricao).HasMaxLength(255);
            entity.Property(e => e.MinTipo).HasMaxLength(1);
            entity.Property(e => e.MinTipoMovimento).HasMaxLength(2);
            entity.Property(e => e.MinTipoOperacao).HasMaxLength(1);
            entity.Property(e => e.MinValor).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.CntCodigoNavigation).WithMany(p => p.TbMovimentoInvestimentos)
                .HasForeignKey(d => d.CntCodigo)
                .HasConstraintName("FK_Tb_MovimentoInvestimento_Tb_Contas");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbMovimentoInvestimentos)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_MovimentoInvestimento_Tb_Empresa");

            entity.HasOne(d => d.PlcCodigoNavigation).WithMany(p => p.TbMovimentoInvestimentos)
                .HasForeignKey(d => d.PlcCodigo)
                .HasConstraintName("FK_Tb_MovimentoInvestimento_Tb_PlanoContas");
        });

        modelBuilder.Entity<TbParoquium>(entity =>
        {
            entity.HasKey(e => e.PrqCodigo).HasName("PK__Tb_Paroq__5994DBA798474AF5");

            entity.ToTable("Tb_Paroquia");

            entity.HasIndex(e => e.PrqCodigo, "UQ__Tb_Paroq__5994DBA6E5F241B7").IsUnique();

            entity.Property(e => e.PrqNome).HasMaxLength(100);

            entity.HasOne(d => d.CidCodigoNavigation).WithMany(p => p.TbParoquia)
                .HasForeignKey(d => d.CidCodigo)
                .HasConstraintName("FK_Tb_Paroquia_Tb_Cidades");
        });

        modelBuilder.Entity<TbParticipante>(entity =>
        {
            entity.HasKey(e => e.ParCodigo).HasName("PK__Tb_Parti__1B33EDC700E123AC");

            entity.ToTable("Tb_Participantes");

            entity.HasIndex(e => e.ParCodigo, "UQ__Tb_Parti__1B33EDC60A750313").IsUnique();

            entity.Property(e => e.ParCpf).HasMaxLength(50);
            entity.Property(e => e.ParEmail).HasMaxLength(255);
            entity.Property(e => e.ParEndereco).HasMaxLength(100);
            entity.Property(e => e.ParFone).HasMaxLength(50);
            entity.Property(e => e.ParNome).HasMaxLength(150);

            entity.HasOne(d => d.CidCodigoNavigation).WithMany(p => p.TbParticipantes)
                .HasForeignKey(d => d.CidCodigo)
                .HasConstraintName("FK_Tb_Participantes_Tb_Cidades");
        });

        modelBuilder.Entity<TbParticipantesCupon>(entity =>
        {
            entity.HasKey(e => e.PcpCodigo).HasName("PK__Tb_Parti__7370AAAF5B3F6BD8");

            entity.ToTable("Tb_ParticipantesCupons");

            entity.HasIndex(e => e.PcpCodigo, "UQ__Tb_Parti__7370AAAE5FDA1B72").IsUnique();

            entity.HasOne(d => d.CupCodigoNavigation).WithMany(p => p.TbParticipantesCupons)
                .HasForeignKey(d => d.CupCodigo)
                .HasConstraintName("FK_Tb_ParticipantesCupons_Tb_Cupons");

            entity.HasOne(d => d.ParCodigoNavigation).WithMany(p => p.TbParticipantesCupons)
                .HasForeignKey(d => d.ParCodigo)
                .HasConstraintName("FK_Tb_ParticipantesCupons_Tb_Participantes");
        });

        modelBuilder.Entity<TbPermissao>(entity =>
        {
            entity.HasKey(e => e.PerCodigo).HasName("PK__Tb_Permi__FC98D07E6B3FC69C");

            entity.ToTable("Tb_Permissao");

            entity.HasIndex(e => e.PerCodigo, "UQ__Tb_Permi__FC98D07F6E282091").IsUnique();

            entity.HasOne(d => d.TelCodigoNavigation).WithMany(p => p.TbPermissaos)
                .HasForeignKey(d => d.TelCodigo)
                .HasConstraintName("FK_Tb_Permissao_Tb_Telas");

            entity.HasOne(d => d.UsuCodigoNavigation).WithMany(p => p.TbPermissaos)
                .HasForeignKey(d => d.UsuCodigo)
                .HasConstraintName("FK_Tb_Permissao_Tb_Usuarios");
        });

        modelBuilder.Entity<TbPessoa>(entity =>
        {
            entity.HasKey(e => e.PesCodigo).HasName("PK__Tb_Pesso__7A20C906EA0F96CC");

            entity.ToTable("Tb_Pessoas");

            entity.HasIndex(e => e.PesCodigo, "UQ__Tb_Pesso__7A20C9072507AD36").IsUnique();

            entity.Property(e => e.PesCpfcnpj).HasColumnName("PesCPFCNPJ");
            entity.Property(e => e.PesNome).HasMaxLength(100);

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbPessoas)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_Pessoas_Tb_Empresa");
        });

        modelBuilder.Entity<TbPlanoConta>(entity =>
        {
            entity.HasKey(e => e.PlcCodigo).HasName("PK__Tb_Plano__B74A138E8E9C0D2F");

            entity.ToTable("Tb_PlanoContas");

            entity.HasIndex(e => e.PlcCodigo, "UQ__Tb_Plano__B74A138F4688C07D").IsUnique();

            entity.Property(e => e.PlcDescricao).HasMaxLength(255);
            entity.Property(e => e.PlcTipo).HasMaxLength(1);

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbPlanoConta)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_PlanoContas_Tb_Empresa");
        });

        modelBuilder.Entity<TbPremio>(entity =>
        {
            entity.HasKey(e => e.PreCodigo).HasName("PK__Tb_Premi__BC7C175E3A0098F8");

            entity.ToTable("Tb_Premios");

            entity.HasIndex(e => e.PreCodigo, "UQ__Tb_Premi__BC7C175FA5122EC6").IsUnique();

            entity.Property(e => e.PreDescricao).HasMaxLength(255);
            entity.Property(e => e.PreNome).HasMaxLength(255);

            entity.HasOne(d => d.PrmCodigoNavigation).WithMany(p => p.TbPremios)
                .HasForeignKey(d => d.PrmCodigo)
                .HasConstraintName("FK_Tb_Premios_Tb_Premios");
        });

        modelBuilder.Entity<TbProduto>(entity =>
        {
            entity.HasKey(e => e.ProCodigo).HasName("PK__Tb_Produ__90746C2298EED2D5");

            entity.ToTable("Tb_Produtos");

            entity.HasIndex(e => e.ProCodigo, "UQ__Tb_Produ__90746C2330FBC2EC").IsUnique();

            entity.Property(e => e.ProCodBarras).HasMaxLength(255);
            entity.Property(e => e.ProMedida).HasMaxLength(255);
            entity.Property(e => e.ProNome).HasMaxLength(100);
            entity.Property(e => e.ProObservacao).HasColumnType("text");
            entity.Property(e => e.ProValor).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.CatCodigoNavigation).WithMany(p => p.TbProdutos)
                .HasForeignKey(d => d.CatCodigo)
                .HasConstraintName("FK_Tb_Produtos_Tb_Categorias");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbProdutos)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_Produtos_Tb_Empresa");
        });

        modelBuilder.Entity<TbPromocao>(entity =>
        {
            entity.HasKey(e => e.PrmCodigo).HasName("PK__Tb_Promo__7EA915095874ED9F");

            entity.ToTable("Tb_Promocao");

            entity.HasIndex(e => e.PrmCodigo, "UQ__Tb_Promo__7EA915081AF4DEA2").IsUnique();

            entity.Property(e => e.PrmDescricao).HasMaxLength(255);
            entity.Property(e => e.PrmNome).HasMaxLength(150);

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbPromocaos)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_Promocao_Tb_Empresa");
        });

        modelBuilder.Entity<TbQuarto>(entity =>
        {
            entity.HasKey(e => e.QuaCodigo).HasName("PK__Tb_Quart__45BEC70E334A6542");

            entity.ToTable("Tb_Quartos");

            entity.HasIndex(e => e.QuaCodigo, "UQ__Tb_Quart__45BEC70FF5D08AA0").IsUnique();

            entity.Property(e => e.QuaNome).HasMaxLength(50);

            entity.HasOne(d => d.BloCodigoNavigation).WithMany(p => p.TbQuartos)
                .HasForeignKey(d => d.BloCodigo)
                .HasConstraintName("FK_Tb_Quartos_Tb_Blocos");

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbQuartos)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_Quartos_Tb_Empresa");
        });

        modelBuilder.Entity<TbQuartoPessoa>(entity =>
        {
            entity.HasKey(e => e.QupCodigo).HasName("PK__Tb_Quart__4F44D6A3655FAF5C");

            entity.ToTable("Tb_QuartoPessoa");

            entity.HasIndex(e => e.QupCodigo, "UQ__Tb_Quart__4F44D6A2BB61534E").IsUnique();

            entity.HasOne(d => d.EvpCodigoNavigation).WithMany(p => p.TbQuartoPessoas)
                .HasForeignKey(d => d.EvpCodigo)
                .HasConstraintName("FK_Tb_QuartoPessoa_Tb_EventoPessoas");

            entity.HasOne(d => d.EvqCodigoNavigation).WithMany(p => p.TbQuartoPessoas)
                .HasForeignKey(d => d.EvqCodigo)
                .HasConstraintName("FK_Tb_QuartoPessoa_Tb_EventoQuartos");
        });

        modelBuilder.Entity<TbServico>(entity =>
        {
            entity.HasKey(e => e.SerCodigo).HasName("PK__Tb_Servi__D1C8C4DA396B717D");

            entity.ToTable("Tb_Servicos");

            entity.HasIndex(e => e.SerCodigo, "UQ__Tb_Servi__D1C8C4DBD5558ACC").IsUnique();

            entity.Property(e => e.SerNome).HasMaxLength(100);

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbServicos)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_Servicos_Tb_Empresa");
        });

        modelBuilder.Entity<TbSorteio>(entity =>
        {
            entity.HasKey(e => e.SorCodigo).HasName("PK__Tb_Sorte__9D26301F41E7A75B");

            entity.ToTable("Tb_Sorteios");

            entity.HasIndex(e => e.SorCodigo, "UQ__Tb_Sorte__9D26301E2CE4F8E8").IsUnique();

            entity.Property(e => e.SorData).HasColumnType("datetime");
            entity.Property(e => e.SorVideo).HasMaxLength(255);

            entity.HasOne(d => d.CupCodigoNavigation).WithMany(p => p.TbSorteios)
                .HasForeignKey(d => d.CupCodigo)
                .HasConstraintName("FK_Tb_Sorteios_Tb_Cupons");

            entity.HasOne(d => d.ParCodigoNavigation).WithMany(p => p.TbSorteios)
                .HasForeignKey(d => d.ParCodigo)
                .HasConstraintName("FK_Tb_Sorteios_Tb_Participantes");

            entity.HasOne(d => d.PreCodigoNavigation).WithMany(p => p.TbSorteios)
                .HasForeignKey(d => d.PreCodigo)
                .HasConstraintName("FK_Tb_Sorteios_Tb_Premios");

            entity.HasOne(d => d.PrmCodigoNavigation).WithMany(p => p.TbSorteios)
                .HasForeignKey(d => d.PrmCodigo)
                .HasConstraintName("FK_Tb_Sorteios_Tb_Promocao");
        });

        modelBuilder.Entity<TbTela>(entity =>
        {
            entity.HasKey(e => e.TelCodigo).HasName("PK__Tb_Telas__584EE757D8A0AEC6");

            entity.ToTable("Tb_Telas");

            entity.HasIndex(e => e.TelCodigo, "UQ__Tb_Telas__584EE7566E88BF9B").IsUnique();

            entity.Property(e => e.TelNome).HasMaxLength(255);

            entity.HasOne(d => d.ModCodigoNavigation).WithMany(p => p.TbTelas)
                .HasForeignKey(d => d.ModCodigo)
                .HasConstraintName("FK_Tb_Telas_Tb_Modulo");
        });

        modelBuilder.Entity<TbUsuario>(entity =>
        {
            entity.HasKey(e => e.UsuCodigo).HasName("PK__Tb_Usuar__B1AF4B5A8E1EE7B6");

            entity.ToTable("Tb_Usuarios");

            entity.HasIndex(e => e.UsuCodigo, "Tb_Usuarios_index_0");

            entity.HasIndex(e => e.UsuCodigo, "UQ__Tb_Usuar__B1AF4B5B4DA4A5CA").IsUnique();

            entity.Property(e => e.UsuAdmin)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.UsuCodigoFirebase).HasMaxLength(255);
            entity.Property(e => e.UsuEmail).HasMaxLength(255);
            entity.Property(e => e.UsuNome).HasMaxLength(100);
            entity.Property(e => e.UsuSenha).HasMaxLength(255);

            entity.HasOne(d => d.EmpCodigoNavigation).WithMany(p => p.TbUsuarios)
                .HasForeignKey(d => d.EmpCodigo)
                .HasConstraintName("FK_Tb_Usuarios_Tb_Empresa");
        });

        modelBuilder.Entity<TbUsuarioModulo>(entity =>
        {
            entity.HasKey(e => e.UsmCodigo).HasName("PK__Tb_Usuar__334C89DB41DAD9A0");

            entity.ToTable("Tb_Usuario_Modulo");

            entity.HasIndex(e => e.UsmCodigo, "UQ__Tb_Usuar__334C89DA098E5B58").IsUnique();

            entity.HasOne(d => d.ModCodigoNavigation).WithMany(p => p.TbUsuarioModulos)
                .HasForeignKey(d => d.ModCodigo)
                .HasConstraintName("FK_Tb_Usuario_Modulo_Tb_Modulo");

            entity.HasOne(d => d.UsuCodigoNavigation).WithMany(p => p.TbUsuarioModulos)
                .HasForeignKey(d => d.UsuCodigo)
                .HasConstraintName("FK_Tb_Usuario_Modulo_Tb_Usuarios");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
