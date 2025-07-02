
CREATE TABLE [Tb_Permissao] (
	[PerCodigo] INT NOT NULL IDENTITY UNIQUE,
	[PerAdd] BIT,
	[PerEdit] BIT,
	[PerDelete] BIT,
	[PerAcao] BIT,
	[TelCodigo] INT,
	[UsuCodigo] INT,
	PRIMARY KEY([PerCodigo])
);
GO

CREATE TABLE [Tb_Empresa] (
	[EmpCodigo] INT NOT NULL IDENTITY UNIQUE,
	[EmpNome] NVARCHAR(150),
	[EmpCNPJ] INT UNIQUE,
	[EmpCidade] NVARCHAR(20),
	[EmpEstado] NVARCHAR(2),
	PRIMARY KEY([EmpCodigo])
);
GO

CREATE INDEX [Tb_Empresa_index_0]
ON [Tb_Empresa] ([EmpCodigo]);
GO

CREATE TABLE [Tb_Usuarios] (
	[UsuCodigo] INT NOT NULL IDENTITY UNIQUE,
	[UsuNome] NVARCHAR(100),
	[UsuEmail] NVARCHAR(255),
	[UsuSenha] NVARCHAR(255),
	[UsuCodigoFirebase] NVARCHAR(255),
	[UsuAdmin] BINARY(1),
	[EmpCodigo] INT,
	PRIMARY KEY([UsuCodigo])
);
GO

CREATE INDEX [Tb_Usuarios_index_0]
ON [Tb_Usuarios] ([UsuCodigo]);
GO

CREATE TABLE [Tb_Modulo] (
	[ModCodigo] INT NOT NULL IDENTITY UNIQUE,
	[ModNome] NVARCHAR(255),
	PRIMARY KEY([ModCodigo])
);
GO

CREATE TABLE [Tb_Telas] (
	[TelCodigo] INT NOT NULL IDENTITY UNIQUE,
	[ModCodigo] INT,
	[TelNome] NVARCHAR(255),
	PRIMARY KEY([TelCodigo])
);
GO

CREATE TABLE [Tb_Usuario_Modulo] (
	[UsmCodigo] INT NOT NULL IDENTITY UNIQUE,
	[UsuCodigo] INT,
	[ModCodigo] INT,
	PRIMARY KEY([UsmCodigo])
);
GO

CREATE TABLE [Tb_Cidades] (
	[CidCodigo] INT NOT NULL IDENTITY UNIQUE,
	[CidNome] NVARCHAR(50),
	[CidUF] NVARCHAR(2),
	PRIMARY KEY([CidCodigo])
);
GO

CREATE TABLE [Tb_Servicos] (
	[SerCodigo] INT NOT NULL IDENTITY UNIQUE,
	[SerNome] NVARCHAR(100),
	[EmpCodigo] INT,
	PRIMARY KEY([SerCodigo])
);
GO

CREATE TABLE [Tb_Contrato] (
	[CntCodigo] INT NOT NULL IDENTITY UNIQUE,
	[PesCodigo] INT,
	[MctCodigo] INT,
	[EmpCodigo] INT,
	[CntNumero] INT,
	[CntData] DATE,
	[CntInicio] DATE,
	[CntFim] DATE,
	[CntValor] DECIMAL,
	[CntArquivo] VARBINARY(255),
	[CntObservacao] TEXT,
	PRIMARY KEY([CntCodigo])
);
GO

CREATE TABLE [Tb_ModeloContratos] (
	[MctCodigo] INT NOT NULL IDENTITY UNIQUE,
	[EmpCodigo] INT,
	[MctNome] NVARCHAR(255),
	[MctConteudo] TEXT,
	PRIMARY KEY([MctCodigo])
);
GO

CREATE TABLE [Tb_Hospedes] (
	[HosCodigo] INT NOT NULL IDENTITY UNIQUE,
	[HosNome] NVARCHAR(100),
	[HosGenero] NVARCHAR(1),
	[HosTelefone] NVARCHAR(13),
	[HosCPF] INT,
	[HosStatus] BIT,
	[HOsConjugue] INT,
	[ComCodigo] INT,
	[HosResponsavel] BINARY(1),
	[HosCatequista] BINARY(1),
	[HosSalmista] BINARY(1),
	[HosObservacao] TEXT,
	[EmpCodigo] INT,
	PRIMARY KEY([HosCodigo])
);
GO

CREATE TABLE [Tb_Comunidades] (
	[ComCodigo] INT NOT NULL IDENTITY UNIQUE,
	[ComNumero] INT,
	[PrqCodigo] INT,
	[EmpCodigo] INT,
	PRIMARY KEY([ComCodigo])
);
GO

CREATE TABLE [Tb_Paroquia] (
	[PrqCodigo] INT NOT NULL IDENTITY UNIQUE,
	[PrqNome] NVARCHAR(100),
	[CidCodigo] INT,
	PRIMARY KEY([PrqCodigo])
);
GO

CREATE TABLE [Tb_Blocos] (
	[BloCodigo] INT NOT NULL IDENTITY UNIQUE,
	[BloNome] NVARCHAR(100),
	PRIMARY KEY([BloCodigo])
);
GO

CREATE TABLE [Tb_Quartos] (
	[QuaCodigo] INT NOT NULL IDENTITY UNIQUE,
	[QuaNome] NVARCHAR(50),
	[BloCodigo] INT,
	[QuaQtdCamas] INT,
	[EmpCodigo] INT,
	PRIMARY KEY([QuaCodigo])
);
GO

CREATE TABLE [Tb_Eventos] (
	[EveCodigo] INT NOT NULL IDENTITY UNIQUE,
	[EveNome] NVARCHAR(100),
	[EveStatus] BIT,
	[EveDataInicio] DATETIME,
	[EveDataFim] DATETIME,
	[EveValor] DECIMAL,
	[EveTipoCobranca] NVARCHAR(1),
	[EveObservacao] TEXT,
	[EmpCodigo] INT,
	PRIMARY KEY([EveCodigo])
);
GO

CREATE TABLE [Tb_EventoDespesa] (
	[EdpCodigo] INT NOT NULL IDENTITY UNIQUE,
	[EdpServico] BIT,
	[EdpProduto] BIT,
	[EdpQuantidade] INT,
	[EveCodigo] INT,
	[EdpTipoDespesa] NVARCHAR(1),
	[SerCodigo] INT,
	[ProCodigo] INT,
	[EdpValor] DECIMAL,
	[EdpData] DATE,
	PRIMARY KEY([EdpCodigo])
);
GO

CREATE TABLE [Tb_EventoPessoas] (
	[EvpCodigo] INT NOT NULL IDENTITY UNIQUE,
	[PesCodigo] INT,
	[EveCodigo] INT,
	[EvpPagante] BIT,
	[EvpCobrante] BIT,
	PRIMARY KEY([EvpCodigo])
);
GO

CREATE TABLE [Tb_EventoQuartos] (
	[EvqCodigo] INT NOT NULL IDENTITY UNIQUE,
	[EveCodigo] INT,
	[QuaCodigo] INT,
	PRIMARY KEY([EvqCodigo])
);
GO

CREATE TABLE [Tb_QuartoPessoa] (
	[QupCodigo] INT NOT NULL IDENTITY UNIQUE,
	[EvpCodigo] INT,
	[EvqCodigo] INT,
	[QupCheckin] BIT,
	[QupNaoVem] BIT,
	[QupChave] BIT,
	PRIMARY KEY([QupCodigo])
);
GO

CREATE TABLE [Tb_Categorias] (
	[CatCodigo] INT NOT NULL IDENTITY UNIQUE,
	[CatNome] NVARCHAR(100),
	[EmpCodigo] INT,
	PRIMARY KEY([CatCodigo])
);
GO

CREATE TABLE [Tb_Produtos] (
	[ProCodigo] INT NOT NULL IDENTITY UNIQUE,
	[ProNome] NVARCHAR(100),
	[ProCodBarras] NVARCHAR(255),
	[ProMedida] NVARCHAR(255),
	[ProQuantidade] INT,
	[CatCodigo] INT,
	[EmpCodigo] INT,
	[ProValor] DECIMAL,
	[ProMargemLucro] FLOAT,
	[ProObservacao] TEXT,
	PRIMARY KEY([ProCodigo])
);
GO

CREATE TABLE [Tb_MovimentoEstoque] (
	[MovCodigo] INT NOT NULL IDENTITY UNIQUE,
	[ProCodigo] INT,
	[EmpCodigo] INT,
	[UsuCodigo] INT,
	[MovQuantidade] INT,
	[MovData] DATE,
	[MovTipo] NVARCHAR(1),
	[MovObservacao] TEXT,
	PRIMARY KEY([MovCodigo])
);
GO

CREATE TABLE [Tb_Compras] (
	[ComCodigo] INT NOT NULL IDENTITY UNIQUE,
	[ComNumero] INT,
	[ComObservacao] TEXT,
	[PesCodigo] INT,
	[CtpCodigo] INT,
	[ComData] DATE,
	[ComStatus] NVARCHAR(1),
	[EmpCodigo] INT,
	[ComPrazo] DATE,
	[SoliciCodigo] INT,
	[AutoriCodigo] INT,
	[ComJustificativa] TEXT,
	[ComDataExecucao] DATE,
	[ComAutorizacao] DATE,
	[ComArquivo] VARBINARY(255),
	PRIMARY KEY([ComCodigo])
);
GO

CREATE TABLE [Tb_ComprasItens] (
	[CmiCodigo] INT NOT NULL IDENTITY UNIQUE,
	[ComCodigo] INT,
	[ProCodigo] INT,
	[CmiValor] DECIMAL,
	[CmiQuantidade] FLOAT,
	[CmiValorTotal] DECIMAL,
	PRIMARY KEY([CmiCodigo])
);
GO

CREATE TABLE [Tb_Pessoas] (
	[PesCodigo] INT NOT NULL IDENTITY UNIQUE,
	[PesNome] NVARCHAR(100),
	[PesCPFCNPJ] INT,
	[PesFornecedor] BIT,
	[PesFuncionario] BIT,
	[PesCliente] BIT,
	[EmpCodigo] INT,
	PRIMARY KEY([PesCodigo])
);
GO

CREATE TABLE [Tb_Participantes] (
	[ParCodigo] INT NOT NULL IDENTITY UNIQUE,
	[ParNome] NVARCHAR(150),
	[ParCpf] NVARCHAR(50),
	[ParFone] NVARCHAR(50),
	[ParDataNascimento] DATE,
	[ParEndereco] NVARCHAR(100),
	[ParEmail] NVARCHAR(255),
	[CidCodigo] INT,
	PRIMARY KEY([ParCodigo])
);
GO

CREATE TABLE [Tb_Premios] (
	[PreCodigo] INT NOT NULL IDENTITY UNIQUE,
	[PreNome] NVARCHAR(255),
	[PreDescricao] NVARCHAR(255),
	[PrmCodigo] INT,
	PRIMARY KEY([PreCodigo])
);
GO

CREATE TABLE [Tb_Promocao] (
	[PrmCodigo] INT NOT NULL IDENTITY UNIQUE,
	[PrmNome] NVARCHAR(150),
	[PrmDataInicio] DATE,
	[PrmDataFim] DATE,
	[PrmDescricao] NVARCHAR(255),
	[EmpCodigo] INT,
	PRIMARY KEY([PrmCodigo])
);
GO

CREATE TABLE [Tb_Cupons] (
	[CupCodigo] INT NOT NULL IDENTITY UNIQUE,
	[CupNumero] NVARCHAR(50),
	[CupSorteado] BIT,
	[CupVendido] BIT,
	[ParCodigo] INT,
	[PrmCodigo] INT,
	PRIMARY KEY([CupCodigo])
);
GO

CREATE TABLE [Tb_Sorteios] (
	[SorCodigo] INT NOT NULL IDENTITY UNIQUE,
	[SorData] DATETIME,
	[ParCodigo] INT,
	[PreCodigo] INT,
	[CupCodigo] INT,
	[PrmCodigo] INT,
	[SorVideo] NVARCHAR(255),
	PRIMARY KEY([SorCodigo])
);
GO

CREATE TABLE [Tb_ParticipantesCupons] (
	[PcpCodigo] INT NOT NULL IDENTITY UNIQUE,
	[CupCodigo] INT,
	[ParCodigo] INT,
	PRIMARY KEY([PcpCodigo])
);
GO

CREATE TABLE [Tb_ContasPagar] (
	[CtpCodigo] INT NOT NULL IDENTITY UNIQUE,
	[PesCodigo] INT,
	[PlcCodigo] INT,
	[CtpDescricao] NVARCHAR(255),
	[CtpData] DATE,
	[CtpDataVencimento] DATE,
	[CtpValor] DECIMAL,
	[CtpParcela] INT,
	[CtpStatus] BIT,
	[EmpCodigo] INT,
	PRIMARY KEY([CtpCodigo])
);
GO

CREATE TABLE [Tb_ContasReceber] (
	[CtrCodigo] INT NOT NULL IDENTITY UNIQUE,
	[PesCodigo] INT,
	[PlcCodigo] INT,
	[CtrDescricao] TEXT,
	[CtrData] DATE,
	[CtrDataVencimento] DATE,
	[CtrStatus] BIT,
	[CtrValor] DECIMAL,
	[CtrParcela] INT,
	[CtrSituacao] BIT,
	[EmpCodigo] INT,
	PRIMARY KEY([CtrCodigo])
);
GO

CREATE TABLE [Tb_Caixa] (
	[CaiCodigo] INT NOT NULL IDENTITY UNIQUE,
	[EmpCodigo] INT,
	[CaiStatus] NVARCHAR(1),
	[CaiDataAbertura] DATETIME,
	[CaiDataFechamento] DATETIME,
	[CaiSaldoFechamento] DECIMAL,
	PRIMARY KEY([CaiCodigo])
);
GO

CREATE TABLE [Tb_ContasReceberItens] (
	[CriCodigo] INT NOT NULL IDENTITY UNIQUE,
	[CtrCodigo] INT,
	[CriValor] DECIMAL,
	[CriDesconto] DECIMAL,
	[CriDataPagamento] DATE,
	PRIMARY KEY([CriCodigo])
);
GO

CREATE TABLE [Tb_ContasPagarItens] (
	[CpiCodigo] INT NOT NULL IDENTITY UNIQUE,
	[CtpCodigo] INT,
	[CpiValor] DECIMAL,
	[CpiDesconto] DECIMAL,
	[CpiDataPagamento] DATE,
	PRIMARY KEY([CpiCodigo])
);
GO

CREATE TABLE [Tb_PlanoContas] (
	[PlcCodigo] INT NOT NULL IDENTITY UNIQUE,
	[PlcDescricao] NVARCHAR(255),
	[PlcTipo] NVARCHAR(1),
	[EmpCodigo] INT,
	PRIMARY KEY([PlcCodigo])
);
GO

CREATE TABLE [Tb_Bancos] (
	[BanCodigo] INT NOT NULL IDENTITY UNIQUE,
	[EmpCodigo] INT,
	[BanNumero] INT,
	[BanDescricao] NVARCHAR(50),
	[BanLogo] TEXT,
	[BanDigito] NVARCHAR(2),
	PRIMARY KEY([BanCodigo])
);
GO

CREATE TABLE [Tb_MovimentoCaixa] (
	[McxCodigo] INT NOT NULL IDENTITY UNIQUE,
	[CaiCodigo] INT,
	[McxData] DATETIME,
	[McxValor] DECIMAL,
	[McxDescricao] TEXT,
	[McxTipo] NVARCHAR(1),
	[McxFormaPagamento] NVARCHAR(10),
	[McxCodigoMovimento] INT,
	PRIMARY KEY([McxCodigo])
);
GO

CREATE TABLE [Tb_Lancamentos] (
	[LncCodigo] INT NOT NULL IDENTITY UNIQUE,
	[EmpCodigo] INT,
	[PesCodigo] INT,
	[PlcCodigo] INT,
	[LncTipo] BIT,
	[LncDescricao] TEXT,
	[LncValor] DECIMAL,
	[LncFaturado] BIT,
	[LncTipoPeriodo] NVARCHAR(1),
	[LncDataVencimento] DATE,
	PRIMARY KEY([LncCodigo])
);
GO

CREATE TABLE [Tb_Contas] (
	[CntCodigo] INT NOT NULL IDENTITY UNIQUE,
	[BanCodigo] INT,
	[EmpCodigo] INT,
	[CntAgencia] NVARCHAR(10),
	[CntNomeAgencia] NVARCHAR(20),
	[CntConta] NVARCHAR(15),
	[CntTitular] NVARCHAR(50),
	[CntAgenciaDigito] NVARCHAR(3),
	[CntContaDigito] NVARCHAR(3),
	[CntTipoConta] NVARCHAR(1),
	[CntAtiva] BIT,
	PRIMARY KEY([CntCodigo])
);
GO

CREATE TABLE [Tb_MovimentoContaCorrente] (
	[MccCodigo] INT NOT NULL IDENTITY UNIQUE,
	[EmpCodigo] INT,
	[CntCodigo] INT,
	[MccDescricao] NVARCHAR(255),
	[MccData] DATE,
	[MccValor] DECIMAL,
	[MccTipo] NVARCHAR(1),
	[MccDocumento] NVARCHAR(255),
	PRIMARY KEY([MccCodigo])
);
GO

CREATE TABLE [Tb_Gaveta] (
	[GavCodigo  ] INT NOT NULL IDENTITY UNIQUE,
	[EmpCodigo] INT,
	[GavData] DATE,
	[GavValor] NUMERIC,
	[GavObservacao] TEXT,
	[GavConciliado] NVARCHAR(1),
	[GavTipoMovimento] NVARCHAR(2),
	[GavCodigoMovimento] INT,
	[GavDescricao] NVARCHAR(255),
	[GavTipo] NVARCHAR(1),
	PRIMARY KEY([GavCodigo  ])
);
GO

CREATE TABLE [Tb_MovimentoInvestimento] (
	[MinCodigo] INT NOT NULL IDENTITY UNIQUE,
	[EmpCodigo] INT,
	[CntCodigo] INT,
	[PlcCodigo] INT,
	[MinData] DATE,
	[MinValor] DECIMAL,
	[MinTipo] NVARCHAR(1),
	[MinTipoMovimento] NVARCHAR(2),
	[MinCodigoMovimento] INT,
	[MinDescricao] NVARCHAR(255),
	[MinTipoOperacao] NVARCHAR(1),
	PRIMARY KEY([MinCodigo])
);
GO

ALTER TABLE [Tb_Usuarios]
ADD FOREIGN KEY([EmpCodigo]) REFERENCES [Tb_Empresa]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Telas]
ADD FOREIGN KEY([ModCodigo]) REFERENCES [Tb_Modulo]([ModNome])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Usuarios]
ADD FOREIGN KEY([UsuCodigo]) REFERENCES [Tb_Permissao]([UsuCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Telas]
ADD FOREIGN KEY([TelCodigo]) REFERENCES [Tb_Permissao]([TelCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Usuarios]
ADD FOREIGN KEY([UsuCodigo]) REFERENCES [Tb_Usuario_Modulo]([UsuCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Modulo]
ADD FOREIGN KEY([ModCodigo]) REFERENCES [Tb_Usuario_Modulo]([ModCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Comunidades]
ADD FOREIGN KEY([ComCodigo]) REFERENCES [Tb_Hospedes]([ComCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Paroquia]
ADD FOREIGN KEY([PrqCodigo]) REFERENCES [Tb_Comunidades]([PrqCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Cidades]
ADD FOREIGN KEY([CidCodigo]) REFERENCES [Tb_Paroquia]([CidCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Blocos]
ADD FOREIGN KEY([BloCodigo]) REFERENCES [Tb_Quartos]([BloCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Empresa]
ADD FOREIGN KEY([EmpEstado]) REFERENCES [Tb_Hospedes]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Empresa]
ADD FOREIGN KEY([EmpEstado]) REFERENCES [Tb_Quartos]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Empresa]
ADD FOREIGN KEY([EmpCodigo]) REFERENCES [Tb_Comunidades]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Empresa]
ADD FOREIGN KEY([EmpEstado]) REFERENCES [Tb_Eventos]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Eventos]
ADD FOREIGN KEY([EveCodigo]) REFERENCES [Tb_EventoDespesa]([EveCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Hospedes]
ADD FOREIGN KEY([HosNome]) REFERENCES [Tb_EventoPessoas]([PesCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Eventos]
ADD FOREIGN KEY([EveCodigo]) REFERENCES [Tb_EventoPessoas]([EveCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Quartos]
ADD FOREIGN KEY([QuaCodigo]) REFERENCES [Tb_EventoQuartos]([QuaCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Servicos]
ADD FOREIGN KEY([SerCodigo]) REFERENCES [Tb_EventoDespesa]([SerCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Eventos]
ADD FOREIGN KEY([EveCodigo]) REFERENCES [Tb_EventoQuartos]([EveCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_EventoQuartos]
ADD FOREIGN KEY([EvqCodigo]) REFERENCES [Tb_QuartoPessoa]([EvqCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_EventoPessoas]
ADD FOREIGN KEY([EvpCodigo]) REFERENCES [Tb_QuartoPessoa]([EvpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Categorias]
ADD FOREIGN KEY([CatCodigo]) REFERENCES [Tb_Produtos]([CatCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Produtos]
ADD FOREIGN KEY([ProCodigo]) REFERENCES [Tb_MovimentoEstoque]([ProCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Cidades]
ADD FOREIGN KEY([CidCodigo]) REFERENCES [Tb_Participantes]([CidCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Promocao]
ADD FOREIGN KEY([PrmCodigo]) REFERENCES [Tb_Premios]([PrmCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Participantes]
ADD FOREIGN KEY([ParCodigo]) REFERENCES [Tb_Cupons]([ParCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Promocao]
ADD FOREIGN KEY([PrmCodigo]) REFERENCES [Tb_Cupons]([PrmCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Participantes]
ADD FOREIGN KEY([ParCodigo]) REFERENCES [Tb_Sorteios]([ParCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Premios]
ADD FOREIGN KEY([PreCodigo]) REFERENCES [Tb_Sorteios]([PreCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Promocao]
ADD FOREIGN KEY([PrmCodigo]) REFERENCES [Tb_Sorteios]([PrmCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Cupons]
ADD FOREIGN KEY([CupCodigo]) REFERENCES [Tb_ParticipantesCupons]([CupCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Participantes]
ADD FOREIGN KEY([ParCodigo]) REFERENCES [Tb_ParticipantesCupons]([ParCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_ContasReceber]
ADD FOREIGN KEY([CtrCodigo]) REFERENCES [Tb_ContasReceberItens]([CtrCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_ContasPagar]
ADD FOREIGN KEY([CtpCodigo]) REFERENCES [Tb_ContasPagarItens]([CtpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Empresa]
ADD FOREIGN KEY([EmpCodigo]) REFERENCES [Tb_Promocao]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Empresa]
ADD FOREIGN KEY([EmpCodigo]) REFERENCES [Tb_Produtos]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Empresa]
ADD FOREIGN KEY([EmpCodigo]) REFERENCES [Tb_Categorias]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Empresa]
ADD FOREIGN KEY([EmpCodigo]) REFERENCES [Tb_MovimentoEstoque]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Produtos]
ADD FOREIGN KEY([ProCodigo]) REFERENCES [Tb_ComprasItens]([ProCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Compras]
ADD FOREIGN KEY([ComCodigo]) REFERENCES [Tb_ComprasItens]([ComCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Empresa]
ADD FOREIGN KEY([EmpCodigo]) REFERENCES [Tb_Compras]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Pessoas]
ADD FOREIGN KEY([PesCodigo]) REFERENCES [Tb_Compras]([PesCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Empresa]
ADD FOREIGN KEY([EmpCodigo]) REFERENCES [Tb_Pessoas]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Produtos]
ADD FOREIGN KEY([ProCodigo]) REFERENCES [Tb_EventoDespesa]([ProCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_ContasPagar]
ADD FOREIGN KEY([CtpCodigo]) REFERENCES [Tb_Compras]([CtpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Empresa]
ADD FOREIGN KEY([EmpCodigo]) REFERENCES [Tb_PlanoContas]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Empresa]
ADD FOREIGN KEY([EmpCodigo]) REFERENCES [Tb_ContasPagar]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Empresa]
ADD FOREIGN KEY([EmpCodigo]) REFERENCES [Tb_ContasReceber]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_ContasPagar]
ADD FOREIGN KEY([PesCodigo]) REFERENCES [Tb_Pessoas]([PesCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_PlanoContas]
ADD FOREIGN KEY([PlcCodigo]) REFERENCES [Tb_ContasPagar]([PlcCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Pessoas]
ADD FOREIGN KEY([PesCodigo]) REFERENCES [Tb_ContasReceber]([PesCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_PlanoContas]
ADD FOREIGN KEY([PlcCodigo]) REFERENCES [Tb_ContasReceber]([PlcCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Empresa]
ADD FOREIGN KEY([EmpCodigo]) REFERENCES [Tb_Caixa]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Empresa]
ADD FOREIGN KEY([EmpCodigo]) REFERENCES [Tb_Bancos]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Caixa]
ADD FOREIGN KEY([CaiCodigo]) REFERENCES [Tb_MovimentoCaixa]([CaiCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Bancos]
ADD FOREIGN KEY([BanCodigo]) REFERENCES [Tb_Contas]([BanCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Pessoas]
ADD FOREIGN KEY([PesCodigo]) REFERENCES [Tb_Lancamentos]([PesCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_PlanoContas]
ADD FOREIGN KEY([PlcCodigo]) REFERENCES [Tb_Lancamentos]([PlcCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Contas]
ADD FOREIGN KEY([CntCodigo]) REFERENCES [Tb_MovimentoContaCorrente]([CntCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Empresa]
ADD FOREIGN KEY([EmpCodigo]) REFERENCES [Tb_Gaveta]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Empresa]
ADD FOREIGN KEY([EmpCodigo]) REFERENCES [Tb_MovimentoContaCorrente]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_PlanoContas]
ADD FOREIGN KEY([PlcCodigo]) REFERENCES [Tb_MovimentoInvestimento]([PlcCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Contas]
ADD FOREIGN KEY([CntCodigo]) REFERENCES [Tb_MovimentoInvestimento]([CntCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Empresa]
ADD FOREIGN KEY([EmpCodigo]) REFERENCES [Tb_MovimentoInvestimento]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Empresa]
ADD FOREIGN KEY([EmpCodigo]) REFERENCES [Tb_Contas]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_ModeloContratos]
ADD FOREIGN KEY([MctCodigo]) REFERENCES [Tb_Contrato]([MctCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Pessoas]
ADD FOREIGN KEY([PesCodigo]) REFERENCES [Tb_Contrato]([PesCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Empresa]
ADD FOREIGN KEY([EmpCodigo]) REFERENCES [Tb_Contrato]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Empresa]
ADD FOREIGN KEY([EmpCodigo]) REFERENCES [Tb_ModeloContratos]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Usuarios]
ADD FOREIGN KEY([UsuCodigo]) REFERENCES [Tb_Compras]([SoliciCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Usuarios]
ADD FOREIGN KEY([UsuCodigo]) REFERENCES [Tb_MovimentoEstoque]([UsuCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Usuarios]
ADD FOREIGN KEY([UsuCodigo]) REFERENCES [Tb_Compras]([AutoriCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO
ALTER TABLE [Tb_Empresa]
ADD FOREIGN KEY([EmpCodigo]) REFERENCES [Tb_Servicos]([EmpCodigo])
ON UPDATE NO ACTION ON DELETE NO ACTION;
GO