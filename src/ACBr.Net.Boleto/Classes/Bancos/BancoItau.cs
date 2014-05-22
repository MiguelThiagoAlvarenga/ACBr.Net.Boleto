// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 04-21-2014
//
// Last Modified By : RFTD
// Last Modified On : 04-24-2014
// ***********************************************************************
// <copyright file="BancoDoBrasil.cs" company="">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Collections.Generic;
#region COM Interop Attributes

#if COM_INTEROP
using System.Runtime.InteropServices;
#endif


#endregion COM Interop Attributes
using ACBr.Net.Core;

/// <summary>
/// ACBr.Net.Boleto namespace.
/// </summary>
namespace ACBr.Net.Boleto
{
    #region COM Interop Attributes

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("2E675758-954A-45EE-981F-4C2662AF9CE1")]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

    #endregion COM Interop Attributes
    /// <summary>
    /// Classe BancoDoBrasil. Esta classe n�o pode ser herdada.
    /// </summary>
    public sealed class BancoItau : BancoBase
    {
        #region Fields
        #endregion Fields

        #region Constructor

        /// <summary>
        /// Inicializa uma nova instancia da classe <see cref="BancoDoBrasil" />.
        /// </summary>
        /// <param name="parent">Classe Banco.</param>
        internal BancoItau(Banco parent)
            : base(parent)
        {
            TipoCobranca = TipoCobranca.Itau;
            Digito = 7;
            Nome = "Banco Itau";
            Numero = 341;
            TamanhoMaximoNossoNum = 8;
            TamanhoAgencia = 4;
            TamanhoConta = 5;
            TamanhoCarteira = 3;  
        }

        #endregion Constructor

        #region Propriedades
        #endregion Propriedades

        #region Methods

        /// <summary>
        /// Tipoes the ocorrencia to descricao.
        /// </summary>
        /// <param name="Tipo">The tipo.</param>
        /// <returns>System.String.</returns>
        public override string TipoOcorrenciaToDescricao(TipoOcorrencia Tipo)
        {
            var CodOcorrencia = TipoOCorrenciaToCod(Tipo).ToInt32();   
            switch(CodOcorrencia)
            {
                case 2: return "02-Entrada Confirmada";
                case 3: return "03-Entrada Rejeitada";
                case 4: return "04-Altera��o de Dados - Nova Entrada";
                case 5: return "05-Altera��o de Dados - Baixa";
                case 6: return "06-Liquida��o Normal";
                case 7: return "07-Liquida��o Parcial - Cobran�a Inteligente (B2b)";
                case 8: return "08-Liquida��o Em Cart�rio";
                case 9: return "09-Baixa Simples";
                case 10: return "10-Baixa Por Ter Sido Liquidado";
                case 11: return "11-Em Ser";
                case 12: return "12-Abatimento Concedido";
                case 13: return "13-Abatimento Cancelado";
                case 14: return "14-Vencimento Alterado";
                case 15: return "15-Baixas Rejeitadas";
                case 16: return "16-Instru��es Rejeitadas";
                case 17: return "17-Altera��o de Dados Rejeitados";
                case 18: return "18-Cobran�a Contratual - Instru��es/Altera��es Rejeitadas/Pendentes";
                case 19: return "19-Confirma Recebimento de Instru��o de Protesto";
                case 20: return "20-Confirma Recebimento de Instru��o de Susta��o de Protesto /Tarifa";
                case 21: return "21-Confirma Recebimento de Instru��o de N�o Protestar";
                case 23: return "23-T�tulo Enviado A Cart�rio/Tarifa";
                case 24: return "24-Instru��o de Protesto Rejeitada / Sustada / Pendente";
                case 25: return "25-Alega��es do Sacado";
                case 26: return "26-Tarifa de Aviso de Cobran�a";
                case 27: return "27-Tarifa de Extrato Posi��o (B40x)";
                case 28: return "28-Tarifa de Rela��o das Liquida��es";
                case 29: return "29-Tarifa de Manuten��o de T�tulos Vencidos";
                case 30: return "30-D�bito Mensal de Tarifas (Para Entradas e Baixas)";
                case 32: return "32-Baixa por ter sido Protestado";
                case 33: return "33-Custas de Protesto";
                case 34: return "34-Custas de Susta��o";
                case 35: return "35-Custas de Cart�rio Distribuidor";
                case 36: return "36-Custas de Edital";
                case 37: return "37-Tarifa de Emiss�o de Boleto/Tarifa de Envio de Duplicata";
                case 38: return "38-Tarifa de Instru��o";
                case 39: return "39-Tarifa de Ocorr�ncias";
                case 40: return "40-Tarifa Mensal de Emiss�o de Boleto/Tarifa Mensal de Envio De Duplicata";
                case 41: return "41-D�bito Mensal de Tarifas - Extrato de Posi��o (B4ep/B4ox)";
                case 42: return "42-D�bito Mensal de Tarifas - Outras Instru��es";
                case 43: return "43-D�bito Mensal de Tarifas - Manuten��o de T�tulos Vencidos";
                case 44: return "44-D�bito Mensal de Tarifas - Outras Ocorr�ncias";
                case 45: return "45-D�bito Mensal de Tarifas - Protesto";
                case 46: return "46-D�bito Mensal de Tarifas - Susta��o de Protesto";
                case 47: return "47-Baixa com Transfer�ncia para Desconto";
                case 48: return "48-Custas de Susta��o Judicial";
                case 51: return "51-Tarifa Mensal Ref a Entradas Bancos Correspondentes na Carteira";
                case 52: return "52-Tarifa Mensal Baixas na Carteira";
                case 53: return "53-Tarifa Mensal Baixas em Bancos Correspondentes na Carteira";
                case 54: return "54-Tarifa Mensal de Liquida��es na Carteira";
                case 55: return "55-Tarifa Mensal de Liquida��es em Bancos Correspondentes na Carteira";
                case 56: return "56-Custas de Irregularidade";
                case 57: return "57-Instru��o Cancelada";
                case 59: return "59-Baixa por Cr�dito em C/C Atrav�s do Sispag";
                case 60: return "60-Entrada Rejeitada Carn�";
                case 61: return "61-Tarifa Emiss�o Aviso de Movimenta��o de T�tulos (2154)";
                case 62: return "62-D�bito Mensal de Tarifa - Aviso de Movimenta��o de T�tulos (2154)";
                case 63: return "63-T�tulo Sustado Judicialmente";
                case 64: return "64-Entrada Confirmada com Rateio de Cr�dito";
                case 69: return "69-Cheque Devolvido";
                case 71: return "71-Entrada Registrada, Aguardando Avalia��o";
                case 72: return "72-Baixa por Cr�dito em C/C Atrav�s do Sispag sem T�tulo Correspondente";
                case 73: return "73-Confirma��o de Entrada na Cobran�a Simples - Entrada n�o Aceita na Cobran�a Contratual";
                case 76: return "76-Cheque Compensado";
                default: return string.Format("{0:00}-Outras Ocorrencias", CodOcorrencia);
            }
        }

        /// <summary>
        /// Cods the ocorrencia to tipo.
        /// </summary>
        /// <param name="CodOcorrencia">The cod ocorrencia.</param>
        /// <returns>TipoOcorrencia.</returns>
        public override TipoOcorrencia CodOcorrenciaToTipo(int CodOcorrencia)
        {
            switch(CodOcorrencia)
            {
                case 2: return TipoOcorrencia.RetornoRegistroConfirmado;
                case 3: return TipoOcorrencia.RetornoRegistroRecusado;
                case 4: return TipoOcorrencia.RetornoAlteracaoDadosNovaEntrada;
                case 5: return TipoOcorrencia.RetornoAlteracaoDadosBaixa;
                case 6: return TipoOcorrencia.RetornoLiquidado;
                case 7: return TipoOcorrencia.RetornoLiquidadoParcialmente;
                case 8: return TipoOcorrencia.RetornoLiquidadoEmCartorio;
                case 9: return TipoOcorrencia.RetornoBaixaSimples;
                case 10: return TipoOcorrencia.RetornoBaixaPorTerSidoLiquidado;
                case 11: return TipoOcorrencia.RetornoTituloEmSer;
                case 12: return TipoOcorrencia.RetornoAbatimentoConcedido;
                case 13: return TipoOcorrencia.RetornoAbatimentoCancelado;
                case 14: return TipoOcorrencia.RetornoVencimentoAlterado;
                case 15: return TipoOcorrencia.RetornoBaixaRejeitada;
                case 16: return TipoOcorrencia.RetornoInstrucaoRejeitada;
                case 17: return TipoOcorrencia.RetornoAlteracaoDadosRejeitados;
                case 18: return TipoOcorrencia.RetornoCobrancaContratual;
                case 19: return TipoOcorrencia.RetornoRecebimentoInstrucaoProtestar;
                case 20: return TipoOcorrencia.RetornoRecebimentoInstrucaoSustarProtesto;
                case 21: return TipoOcorrencia.RetornoRecebimentoInstrucaoNaoProtestar;
                case 23: return TipoOcorrencia.RetornoEncaminhadoACartorio;
                case 24: return TipoOcorrencia.RetornoInstrucaoProtestoRejeitadaSustadaOuPendente;
                case 25: return TipoOcorrencia.RetornoAlegacaoDoSacado;
                case 26: return TipoOcorrencia.RetornoTarifaAvisoCobranca;
                case 27: return TipoOcorrencia.RetornoTarifaExtratoPosicao;
                case 28: return TipoOcorrencia.RetornoTarifaDeRelacaoDasLiquidacoes;
                case 29: return TipoOcorrencia.RetornoTarifaDeManutencaoDeTitulosVencidos;
                case 30: return TipoOcorrencia.RetornoDebitoTarifas;
                case 32: return TipoOcorrencia.RetornoBaixaPorProtesto;
                case 33: return TipoOcorrencia.RetornoCustasProtesto;
                case 34: return TipoOcorrencia.RetornoCustasSustacao;
                case 35: return TipoOcorrencia.RetornoCustasCartorioDistribuidor;
                case 36: return TipoOcorrencia.RetornoCustasEdital;
                case 37: return TipoOcorrencia.RetornoTarifaEmissaoBoletoEnvioDuplicata;
                case 38: return TipoOcorrencia.RetornoTarifaInstrucao;
                case 39: return TipoOcorrencia.RetornoTarifaOcorrencias;
                case 40: return TipoOcorrencia.RetornoTarifaMensalEmissaoBoletoEnvioDuplicata;
                case 41: return TipoOcorrencia.RetornoDebitoMensalTarifasExtradoPosicao;
                case 42: return TipoOcorrencia.RetornoDebitoMensalTarifasOutrasInstrucoes;
                case 43: return TipoOcorrencia.RetornoDebitoMensalTarifasManutencaoTitulosVencidos;
                case 44: return TipoOcorrencia.RetornoDebitoMensalTarifasOutrasOcorrencias;
                case 45: return TipoOcorrencia.RetornoDebitoMensalTarifasProtestos;
                case 46: return TipoOcorrencia.RetornoDebitoMensalTarifasSustacaoProtestos;
                case 47: return TipoOcorrencia.RetornoBaixaTransferenciaParaDesconto;
                case 48: return TipoOcorrencia.RetornoCustasSustacaoJudicial;
                case 51: return TipoOcorrencia.RetornoTarifaMensalRefEntradasBancosCorrespCarteira;
                case 52: return TipoOcorrencia.RetornoTarifaMensalBaixasCarteira;
                case 53: return TipoOcorrencia.RetornoTarifaMensalBaixasBancosCorrespCarteira;
                case 54: return TipoOcorrencia.RetornoTarifaMensalLiquidacoesCarteira;
                case 55: return TipoOcorrencia.RetornoTarifaMensalLiquidacoesBancosCorrespCarteira;
                case 56: return TipoOcorrencia.RetornoCustasIrregularidade;
                case 57: return TipoOcorrencia.RetornoInstrucaoCancelada;
                case 59: return TipoOcorrencia.RetornoBaixaCreditoCCAtravesSispag;
                case 60: return TipoOcorrencia.RetornoEntradaRejeitadaCarne;
                case 61: return TipoOcorrencia.RetornoTarifaEmissaoAvisoMovimentacaoTitulos;
                case 62: return TipoOcorrencia.RetornoDebitoMensalTarifaAvisoMovimentacaoTitulos;
                case 63: return TipoOcorrencia.RetornoTituloSustadoJudicialmente;
                case 64: return TipoOcorrencia.RetornoEntradaConfirmadaRateioCredito;
                case 69: return TipoOcorrencia.RetornoChequeDevolvido;
                case 71: return TipoOcorrencia.RetornoEntradaRegistradaAguardandoAvaliacao;
                case 72: return TipoOcorrencia.RetornoBaixaCreditoCCAtravesSispagSemTituloCorresp;
                case 73: return TipoOcorrencia.RetornoConfirmacaoEntradaCobrancaSimples;
                case 76: return TipoOcorrencia.RetornoChequeCompensado; 
                default: return TipoOcorrencia.RetornoOutrasOcorrencias;
            }
        }

        /// <summary>
        /// Tipoes the o correncia to cod.
        /// </summary>
        /// <param name="Tipo">The tipo.</param>
        /// <returns>System.String.</returns>
        public override string TipoOCorrenciaToCod(TipoOcorrencia Tipo)
        {
            switch(Tipo)
            {
                case TipoOcorrencia.RetornoRegistroConfirmado: return "02";
                case TipoOcorrencia.RetornoRegistroRecusado: return "03";
                case TipoOcorrencia.RetornoAlteracaoDadosNovaEntrada: return "04";
                case TipoOcorrencia.RetornoAlteracaoDadosBaixa: return "05";
                case TipoOcorrencia.RetornoLiquidado: return "06";
                case TipoOcorrencia.RetornoLiquidadoParcialmente: return "07";
                case TipoOcorrencia.RetornoLiquidadoEmCartorio: return "08";
                case TipoOcorrencia.RetornoBaixaSimples: return "09";
                case TipoOcorrencia.RetornoBaixaPorTerSidoLiquidado: return "10";
                case TipoOcorrencia.RetornoTituloEmSer: return "11";
                case TipoOcorrencia.RetornoAbatimentoConcedido: return "12";
                case TipoOcorrencia.RetornoAbatimentoCancelado: return "13";
                case TipoOcorrencia.RetornoVencimentoAlterado: return "14";
                case TipoOcorrencia.RetornoBaixaRejeitada: return "15";
                case TipoOcorrencia.RetornoInstrucaoRejeitada: return "16";
                case TipoOcorrencia.RetornoAlteracaoDadosRejeitados: return "17";
                case TipoOcorrencia.RetornoCobrancaContratual: return "18";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoProtestar: return "19";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoSustarProtesto: return "20";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoNaoProtestar: return "21";
                case TipoOcorrencia.RetornoEncaminhadoACartorio: return "23";
                case TipoOcorrencia.RetornoInstrucaoProtestoRejeitadaSustadaOuPendente: return "24";
                case TipoOcorrencia.RetornoAlegacaoDoSacado: return "25";
                case TipoOcorrencia.RetornoTarifaAvisoCobranca: return "26";
                case TipoOcorrencia.RetornoTarifaExtratoPosicao: return "27";
                case TipoOcorrencia.RetornoTarifaDeRelacaoDasLiquidacoes: return "28";
                case TipoOcorrencia.RetornoTarifaDeManutencaoDeTitulosVencidos: return "29";
                case TipoOcorrencia.RetornoDebitoTarifas: return "30";
                case TipoOcorrencia.RetornoBaixaPorProtesto: return "32";
                case TipoOcorrencia.RetornoCustasProtesto: return "33";
                case TipoOcorrencia.RetornoCustasSustacao: return "34";
                case TipoOcorrencia.RetornoCustasCartorioDistribuidor: return "35";
                case TipoOcorrencia.RetornoCustasEdital: return "36";
                case TipoOcorrencia.RetornoTarifaEmissaoBoletoEnvioDuplicata: return "37";
                case TipoOcorrencia.RetornoTarifaInstrucao: return "38";
                case TipoOcorrencia.RetornoTarifaOcorrencias: return "39";
                case TipoOcorrencia.RetornoTarifaMensalEmissaoBoletoEnvioDuplicata: return "40";
                case TipoOcorrencia.RetornoDebitoMensalTarifasExtradoPosicao: return "41";
                case TipoOcorrencia.RetornoDebitoMensalTarifasOutrasInstrucoes: return "42";
                case TipoOcorrencia.RetornoDebitoMensalTarifasManutencaoTitulosVencidos: return "43";
                case TipoOcorrencia.RetornoDebitoMensalTarifasOutrasOcorrencias: return "44";
                case TipoOcorrencia.RetornoDebitoMensalTarifasProtestos: return "45";
                case TipoOcorrencia.RetornoDebitoMensalTarifasSustacaoProtestos: return "46";
                case TipoOcorrencia.RetornoBaixaTransferenciaParaDesconto: return "47";
                case TipoOcorrencia.RetornoCustasSustacaoJudicial: return "48";
                case TipoOcorrencia.RetornoTarifaMensalRefEntradasBancosCorrespCarteira: return "51";
                case TipoOcorrencia.RetornoTarifaMensalBaixasCarteira: return "52";
                case TipoOcorrencia.RetornoTarifaMensalBaixasBancosCorrespCarteira: return "53";
                case TipoOcorrencia.RetornoTarifaMensalLiquidacoesCarteira: return "54";
                case TipoOcorrencia.RetornoTarifaMensalLiquidacoesBancosCorrespCarteira: return "55";
                case TipoOcorrencia.RetornoCustasIrregularidade: return "56";
                case TipoOcorrencia.RetornoInstrucaoCancelada: return "57";
                case TipoOcorrencia.RetornoBaixaCreditoCCAtravesSispag: return "59";
                case TipoOcorrencia.RetornoEntradaRejeitadaCarne: return "60";
                case TipoOcorrencia.RetornoTarifaEmissaoAvisoMovimentacaoTitulos: return "61";
                case TipoOcorrencia.RetornoDebitoMensalTarifaAvisoMovimentacaoTitulos: return "62";
                case TipoOcorrencia.RetornoTituloSustadoJudicialmente: return "63";
                case TipoOcorrencia.RetornoEntradaConfirmadaRateioCredito: return "64";
                case TipoOcorrencia.RetornoChequeDevolvido: return "69";
                case TipoOcorrencia.RetornoEntradaRegistradaAguardandoAvaliacao: return "71";
                case TipoOcorrencia.RetornoBaixaCreditoCCAtravesSispagSemTituloCorresp: return "72";
                case TipoOcorrencia.RetornoConfirmacaoEntradaCobrancaSimples: return "73";
                case TipoOcorrencia.RetornoChequeCompensado: return "76";
                default: return "02";
            }
        }

        /// <summary>
        /// Cods the motivo rejeicao to descricao.
        /// </summary>
        /// <param name="Tipo">The tipo.</param>
        /// <param name="CodMotivo">The cod motivo.</param>
        /// <returns>System.String.</returns>
        public override string CodMotivoRejeicaoToDescricao(TipoOcorrencia Tipo, int CodMotivo)
        {
            switch (Tipo)
            {
                case TipoOcorrencia.RetornoRegistroRecusado:
                case TipoOcorrencia.RetornoEntradaRejeitadaCarne:
                    switch (CodMotivo)
                    {
                        case 3: return "AG. COBRADORA -N�O FOI POSS�VEL ATRIBUIR A AG�NCIA PELO CEP OU CEP INV�LIDO";
                        case 4: return "ESTADO -SIGLA DO ESTADO INV�LIDA";
                        case 5: return "DATA VENCIMENTO -PRAZO DA OPERA��O MENOR QUE PRAZO M�NIMO OU MAIOR QUE O M�XIMO";
                        case 7: return "VALOR DO T�TULO -VALOR DO T�TULO MAIOR QUE 10.000.000,00";
                        case 8: return "NOME DO SACADO -N�O INFORMADO OU DESLOCADO";
                        case 9: return "AGENCIA/CONTA -AG�NCIA ENCERRADA";
                        case 10: return "LOGRADOURO -N�O INFORMADO OU DESLOCADO";
                        case 11: return "CEP -CEP N�O NUM�RICO";
                        case 12: return "SACADOR / AVALISTA -NOME N�O INFORMADO OU DESLOCADO (BANCOS CORRESPONDENTES)";
                        case 13: return "ESTADO/CEP -CEP INCOMPAT�VEL COM A SIGLA DO ESTADO";
                        case 14: return "NOSSO N�MERO -NOSSO N�MERO J� REGISTRADO NO CADASTRO DO BANCO OU FORA DA FAIXA";
                        case 15: return "NOSSO N�MERO -NOSSO N�MERO EM DUPLICIDADE NO MESMO MOVIMENTO";
                        case 18: return "DATA DE ENTRADA -DATA DE ENTRADA INV�LIDA PARA OPERAR COM ESTA CARTEIRA";
                        case 19: return "OCORR�NCIA -OCORR�NCIA INV�LIDA";
                        case 21: return "AG. COBRADORA - CARTEIRA N�O ACEITA DEPOSIT�RIA CORRESPONDENTE/" +
                                         "ESTADO DA AG�NCIA DIFERENTE DO ESTADO DO SACADO/" +
                                         "AG. COBRADORA N�O CONSTA NO CADASTRO OU ENCERRANDO";
                        case 22: return "CARTEIRA -CARTEIRA N�O PERMITIDA (NECESS�RIO CADASTRAR FAIXA LIVRE)";
                        case 26: return "AG�NCIA/CONTA -AG�NCIA/CONTA N�O LIBERADA PARA OPERAR COM COBRAN�A";
                        case 27: return "CNPJ INAPTO -CNPJ DO CEDENTE INAPTO";
                        case 29: return "C�DIGO EMPRESA -CATEGORIA DA CONTA INV�LIDA";
                        case 30: return "ENTRADA BLOQUEADA -ENTRADAS BLOQUEADAS, CONTA SUSPENSA EM COBRAN�A";
                        case 31: return "AG�NCIA/CONTA -CONTA N�O TEM PERMISS�O PARA PROTESTAR (CONTATE SEU GERENTE)";
                        case 35: return "VALOR DO IOF -IOF MAIOR QUE 5%";
                        case 36: return "QTDADE DE MOEDA -QUANTIDADE DE MOEDA INCOMPAT�VEL COM VALOR DO T�TULO";
                        case 37: return "CNPJ/CPF DO SACADO -N�O NUM�RICO OU IGUAL A ZEROS";
                        case 42: return "NOSSO N�MERO -NOSSO N�MERO FORA DE FAIXA";
                        case 52: return "AG. COBRADORA -EMPRESA N�O ACEITA BANCO CORRESPONDENTE";
                        case 53: return "AG. COBRADORA -EMPRESA N�O ACEITA BANCO CORRESPONDENTE - COBRAN�A MENSAGEM";
                        case 54: return "DATA DE VENCTO -BANCO CORRESPONDENTE - T�TULO COM VENCIMENTO INFERIOR A 15 DIAS";
                        case 55: return "DEP/BCO CORRESP -CEP N�O PERTENCE � DEPOSIT�RIA INFORMADA";
                        case 56: return "DT VENCTO/BCO CORRESP -VENCTO SUPERIOR A 180 DIAS DA DATA DE ENTRADA";
                        case 57: return "DATA DE VENCTO -CEP S� DEPOSIT�RIA BCO DO BRASIL COM VENCTO INFERIOR A 8 DIAS";
                        case 60: return "ABATIMENTO -VALOR DO ABATIMENTO INV�LIDO";
                        case 61: return "JUROS DE MORA -JUROS DE MORA MAIOR QUE O PERMITIDO";
                        case 63: return "DESCONTO DE ANTECIPA��O -VALOR DA IMPORT�NCIA POR DIA DE DESCONTO (IDD) N�O PERMITIDO";
                        case 64: return "DATA DE EMISS�O -DATA DE EMISS�O DO T�TULO INV�LIDA";
                        case 65: return "TAXA FINANCTO -TAXA INV�LIDA (VENDOR)";
                        case 66: return "DATA DE VENCTO -INVALIDA/FORA DE PRAZO DE OPERA��O (M�NIMO OU M�XIMO)";
                        case 67: return "VALOR/QTIDADE -VALOR DO T�TULO/QUANTIDADE DE MOEDA INV�LIDO";
                        case 68: return "CARTEIRA -CARTEIRA INV�LIDA";
                        case 69: return "CARTEIRA -CARTEIRA INV�LIDA PARA T�TULOS COM RATEIO DE CR�DITO";
                        case 70: return "AG�NCIA/CONTA -CEDENTE N�O CADASTRADO PARA FAZER RATEIO DE CR�DITO";
                        case 78: return "AG�NCIA/CONTA -DUPLICIDADE DE AG�NCIA/CONTA BENEFICI�RIA DO RATEIO DE CR�DITO";
                        case 80: return "AG�NCIA/CONTA -QUANTIDADE DE CONTAS BENEFICI�RIAS DO RATEIO MAIOR DO QUE O PERMITIDO (M�XIMO DE 30 CONTAS POR T�TULO)";
                        case 81: return "AG�NCIA/CONTA -CONTA PARA RATEIO DE CR�DITO INV�LIDA / N�O PERTENCE AO ITA�";
                        case 82: return "DESCONTO/ABATI-MENTO -DESCONTO/ABATIMENTO N�O PERMITIDO PARA T�TULOS COM RATEIO DE CR�DITO";
                        case 83: return "VALOR DO T�TULO -VALOR DO T�TULO MENOR QUE A SOMA DOS VALORES ESTIPULADOS PARA RATEIO";
                        case 84: return "AG�NCIA/CONTA -AG�NCIA/CONTA BENEFICI�RIA DO RATEIO � A CENTRALIZADORA DE CR�DITO DO CEDENTE";
                        case 85: return "AG�NCIA/CONTA -AG�NCIA/CONTA DO CEDENTE � CONTRATUAL / RATEIO DE CR�DITO N�O PERMITIDO";
                        case 86: return "TIPO DE VALOR -C�DIGO DO TIPO DE VALOR INV�LIDO / N�O PREVISTO PARA T�TULOS COM RATEIO DE CR�DITO";
                        case 87: return "AG�NCIA/CONTA -REGISTRO TIPO 4 SEM INFORMA��O DE AG�NCIAS/CONTAS BENEFICI�RIAS DO RATEIO";
                        case 90: return "NRO DA LINHA -COBRAN�A MENSAGEM - N�MERO DA LINHA DA MENSAGEM INV�LIDO";
                        case 97: return "SEM MENSAGEM -COBRAN�A MENSAGEM SEM MENSAGEM (S� DE CAMPOS FIXOS), POR�M COM REGISTRO DO TIPO 7 OU 8";
                        case 98: return "FLASH INV�LIDO -REGISTRO MENSAGEM SEM FLASH CADASTRADO OU FLASH INFORMADO DIFERENTE DO CADASTRADO";
                        case 99: return "FLASH INV�LIDO -CONTA DE COBRAN�A COM FLASH CADASTRADO E SEM REGISTRO DE MENSAGEM CORRESPONDENTE";
                        case 91: return "DAC -DAC AG�NCIA / CONTA CORRENTE INV�LIDO";
                        case 92: return "DAC -DAC AG�NCIA/CONTA/CARTEIRA/NOSSO N�MERO INV�LIDO";
                        case 93: return "ESTADO -SIGLA ESTADO INV�LIDA";
                        case 94: return "ESTADO -SIGLA ESTADA INCOMPAT�VEL COM CEP DO SACADO";
                        case 95: return "CEP -CEP DO SACADO N�O NUM�RICO OU INV�LIDO";
                        case 96: return "ENDERE�O -ENDERE�O / NOME / CIDADE SACADO INV�LIDO";
                        default: return string.Format("{0:00}-Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoAlteracaoDadosRejeitados:
                    switch (CodMotivo)
                    {
                        case 2: return "AG�NCIA COBRADORA INV�LIDA OU COM O MESMO CONTE�DO";
                        case 4: return "SIGLA DO ESTADO INV�LIDA";
                        case 5: return "DATA DE VENCIMENTO INV�LIDA OU COM O MESMO CONTE�DO";
                        case 6: return "VALOR DO T�TULO COM OUTRA ALTERA��O SIMULT�NEA";
                        case 8: return "NOME DO SACADO COM O MESMO CONTE�DO";
                        case 9: return "AG�NCIA/CONTA INCORRETA";
                        case 11: return "CEP INV�LIDO";
                        case 13: return "SEU N�MERO COM O MESMO CONTE�DO";
                        case 16: return "ABATIMENTO/ALTERA��O DO VALOR DO T�TULO OU SOLICITA��O DE BAIXA BLOQUEADA";
                        case 21: return "AG�NCIA COBRADORA N�O CONSTA NO CADASTRO DE DEPOSIT�RIA OU EM ENCERRAMENTO";
                        case 53: return "INSTRU��O COM O MESMO CONTE�DO";
                        case 54: return "DATA VENCIMENTO PARA BANCOS CORRESPONDENTES INFERIOR AO ACEITO PELO BANCO";
                        case 55: return "ALTERA��ES IGUAIS PARA O MESMO CONTROLE (AG�NCIA/CONTA/CARTEIRA/NOSSO N�MERO)";
                        case 56: return "CGC/CPF INV�LIDO N�O NUM�RICO OU ZERADO";
                        case 57: return "PRAZO DE VENCIMENTO INFERIOR A 15 DIAS";
                        case 60: return "VALOR DE IOF - ALTERA��O N�O PERMITIDA PARA CARTEIRAS DE N.S. - MOEDA VARI�VEL";
                        case 61: return "T�TULO J� BAIXADO OU LIQUIDADO OU N�O EXISTE T�TULO CORRESPONDENTE NO SISTEMA";
                        case 66: return "ALTERA��O N�O PERMITIDA PARA CARTEIRAS DE NOTAS DE SEGUROS - MOEDA VARI�VEL";
                        case 81: return "ALTERA��O BLOQUEADA - T�TULO COM PROTESTO";
                        default: return string.Format("{0:00}-Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoInstrucaoRejeitada:
                    switch (CodMotivo)
                    {
                        case 1: return "INSTRU��O/OCORR�NCIA N�O EXISTENTE";
                        case 6: return "NOSSO N�MERO IGUAL A ZEROS";
                        case 9: return "CGC/CPF DO SACADOR/AVALISTA INV�LIDO";
                        case 10: return "VALOR DO ABATIMENTO IGUAL OU MAIOR QUE O VALOR DO T�TULO";
                        case 14: return "REGISTRO EM DUPLICIDADE";
                        case 15: return "CGC/CPF INFORMADO SEM NOME DO SACADOR/AVALISTA";
                        case 21: return "T�TULO N�O REGISTRADO NO SISTEMA";
                        case 22: return "T�TULO BAIXADO OU LIQUIDADO";
                        case 23: return "INSTRU��O N�O ACEITA POR TER SIDO EMITIDO �LTIMO AVISO AO SACADO";
                        case 24: return "INSTRU��O INCOMPAT�VEL - EXISTE INSTRU��O DE PROTESTO PARA O T�TULO";
                        case 25: return "INSTRU��O INCOMPAT�VEL - N�O EXISTE INSTRU��O DE PROTESTO PARA O T�TULO";
                        case 26: return "INSTRU��O N�O ACEITA POR TER SIDO EMITIDO �LTIMO AVISO AO SACADO";
                        case 27: return "INSTRU��O N�O ACEITA POR N�O TER SIDO EMITIDA A ORDEM DE PROTESTO AO CART�RIO";
                        case 28: return "J� EXISTE UMA MESMA INSTRU��O CADASTRADA ANTERIORMENTE PARA O T�TULO";
                        case 29: return "VALOR L�QUIDO + VALOR DO ABATIMENTO DIFERENTE DO VALOR DO T�TULO REGISTRADO, OU VALOR" +
                                        "DO ABATIMENTO MAIOR QUE 90% DO VALOR DO T�TULO";
                        case 30: return "EXISTE UMA INSTRU��O DE N�O PROTESTAR ATIVA PARA O T�TULO";
                        case 31: return "EXISTE UMA OCORR�NCIA DO SACADO QUE BLOQUEIA A INSTRU��O";
                        case 32: return "DEPOSIT�RIA DO T�TULO = 9999 OU CARTEIRA N�O ACEITA PROTESTO";
                        case 33: return "ALTERA��O DE VENCIMENTO IGUAL � REGISTRADA NO SISTEMA OU QUE TORNA O T�TULO VENCIDO";
                        case 34: return "INSTRU��O DE EMISS�O DE AVISO DE COBRAN�A PARA T�TULO VENCIDO ANTES DO VENCIMENTO";
                        case 35: return "SOLICITA��O DE CANCELAMENTO DE INSTRU��O INEXISTENTE";
                        case 36: return "T�TULO SOFRENDO ALTERA��O DE CONTROLE (AG�NCIA/CONTA/CARTEIRA/NOSSO N�MERO)";
                        case 37: return "INSTRU��O N�O PERMITIDA PARA A CARTEIRA";
                        default: return string.Format("{0:00}-Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoBaixaRejeitada:
                    switch (CodMotivo)
                    {
                        case 1: return "CARTEIRA/N� N�MERO N�O NUM�RICO";
                        case 4: return "NOSSO N�MERO EM DUPLICIDADE NUM MESMO MOVIMENTO";
                        case 5: return "SOLICITA��O DE BAIXA PARA T�TULO J� BAIXADO OU LIQUIDADO";
                        case 6: return "SOLICITA��O DE BAIXA PARA T�TULO N�O REGISTRADO NO SISTEMA";
                        case 7: return "COBRAN�A PRAZO CURTO - SOLICITA��O DE BAIXA P/ T�TULO N�O REGISTRADO NO SISTEMA";
                        case 8: return "SOLICITA��O DE BAIXA PARA T�TULO EM FLOATING";  
                        default: return string.Format("{0:00}-Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoCobrancaContratual:
                    switch (CodMotivo)
                    {
                        case 16: return "ABATIMENTO/ALTERA��O DO VALOR DO T�TULO OU SOLICITA��O DE BAIXA BLOQUEADOS";
                        case 40: return "N�O APROVADA DEVIDO AO IMPACTO NA ELEGIBILIDADE DE GARANTIAS";
                        case 41: return "AUTOMATICAMENTE REJEITADA";
                        case 42: return "CONFIRMA RECEBIMENTO DE INSTRU��O � PENDENTE DE AN�LISE";  
                        default: return string.Format("{0:00}-Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoAlegacaoDoSacado:
                    switch (CodMotivo)
                    {
                        case 1313: return "SOLICITA A PRORROGA��O DO VENCIMENTO PARA";
                        case 1321: return "SOLICITA A DISPENSA DOS JUROS DE MORA";
                        case 1339: return "N�O RECEBEU A MERCADORIA";
                        case 1347: return "A MERCADORIA CHEGOU ATRASADA";
                        case 1354: return "A MERCADORIA CHEGOU AVARIADA";
                        case 1362: return "A MERCADORIA CHEGOU INCOMPLETA";
                        case 1370: return "A MERCADORIA N�O CONFERE COM O PEDIDO";
                        case 1388: return "A MERCADORIA EST� � DISPOSI��O";
                        case 1396: return "DEVOLVEU A MERCADORIA";
                        case 1404: return "N�O RECEBEU A FATURA";
                        case 1412: return "A FATURA EST� EM DESACORDO COM A NOTA FISCAL";
                        case 1420: return "O PEDIDO DE COMPRA FOI CANCELADO";
                        case 1438: return "A DUPLICATA FOI CANCELADA";
                        case 1446: return "QUE NADA DEVE OU COMPROU";
                        case 1453: return "QUE MANT�M ENTENDIMENTOS COM O SACADOR";
                        case 1461: return "QUE PAGAR� O T�TULO EM:";
                        case 1479: return "QUE PAGOU O T�TULO DIRETAMENTE AO CEDENTE EM:";
                        case 1487: return "QUE PAGAR� O T�TULO DIRETAMENTE AO CEDENTE EM:";
                        case 1495: return "QUE O VENCIMENTO CORRETO �:";
                        case 1503: return "QUE TEM DESCONTO OU ABATIMENTO DE:";
                        case 1719: return "SACADO N�O FOI LOCALIZADO; CONFIRMAR ENDERE�O";
                        case 1727: return "SACADO EST� EM REGIME DE CONCORDATA";
                        case 1735: return "SACADO EST� EM REGIME DE FAL�NCIA";
                        case 1750: return "SACADO SE RECUSA A PAGAR JUROS BANC�RIOS";
                        case 1768: return "SACADO SE RECUSA A PAGAR COMISS�O DE PERMAN�NCIA";
                        case 1776: return "N�O FOI POSS�VEL A ENTREGA DO BLOQUETO AO SACADO";
                        case 1784: return "BLOQUETO N�O ENTREGUE, MUDOU-SE/DESCONHECIDO";
                        case 1792: return "BLOQUETO N�O ENTREGUE, CEP ERRADO/INCOMPLETO";
                        case 1800: return "BLOQUETO N�O ENTREGUE, N�MERO N�O EXISTE/ENDERE�O INCOMPLETO";
                        case 1818: return "BLOQUETO N�O RETIRADO PELO SACADO. REENVIADO PELO CORREIO";
                        case 1826: return "ENDERE�O DE E-MAIL INV�LIDO. BLOQUETO ENVIADO PELO CORREIO";  
                        default: return string.Format("{0:00}-Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoInstrucaoProtestoRejeitadaSustadaOuPendente:
                    switch (CodMotivo)
                    {
                        case 1610: return "DOCUMENTA��O SOLICITADA AO CEDENTE";
                        case 3111: return "SUSTA��O SOLICITADA AG. CEDENTE";
                        case 3228: return "ATOS DA CORREGEDORIA ESTADUAL";
                        case 3244: return "PROTESTO SUSTADO / CEDENTE N�O ENTREGOU A DOCUMENTA��O";
                        case 3269: return "DATA DE EMISS�O DO T�TULO INV�LIDA/IRREGULAR";
                        case 3301: return "CGC/CPF DO SACADO INV�LIDO/INCORRETO";
                        case 3319: return "SACADOR/AVALISTA E PESSOA F�SICA";
                        case 3327: return "CEP DO SACADO INCORRETO";
                        case 3335: return "DEPOSIT�RIA INCOMPAT�VEL COM CEP DO SACADO";
                        case 3343: return "CGC/CPF SACADOR INVALIDO/INCORRETO";
                        case 3350: return "ENDERE�O DO SACADO INSUFICIENTE";
                        case 3368: return "PRA�A PAGTO INCOMPAT�VEL COM ENDERE�O";
                        case 3376: return "FALTA N�MERO/ESP�CIE DO T�TULO";
                        case 3384: return "T�TULO ACEITO S/ ASSINATURA DO SACADOR";
                        case 3392: return "T�TULO ACEITO S/ ENDOSSO CEDENTE OU IRREGULAR";
                        case 3400: return "T�TULO SEM LOCAL OU DATA DE EMISS�O";
                        case 3418: return "T�TULO ACEITO COM VALOR EXTENSO DIFERENTE DO NUM�RICO";
                        case 3426: return "T�TULO ACEITO DEFINIR ESP�CIE DA DUPLICATA";
                        case 3434: return "DATA EMISS�O POSTERIOR AO VENCIMENTO";
                        case 3442: return "T�TULO ACEITO DOCUMENTO N�O PROSTEST�VEL";
                        case 3459: return "T�TULO ACEITO EXTENSO VENCIMENTO IRREGULAR";
                        case 3467: return "T�TULO ACEITO FALTA NOME FAVORECIDO";
                        case 3475: return "T�TULO ACEITO FALTA PRA�A DE PAGAMENTO";
                        case 3483: return "T�TULO ACEITO FALTA CPF ASSINANTE CHEQUE"; 
                        default: return string.Format("{0:00}-Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoInstrucaoCancelada:
                    switch (CodMotivo)
                    {
                        case 1156: return "N�O PROTESTAR";
                        case 2261: return "DISPENSAR JUROS/COMISS�O DE PERMAN�NCIA";
                        default: return string.Format("{0:00}-Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoChequeDevolvido:
                    switch (CodMotivo)
                    {
                        case 11: return "CHEQUE SEM FUNDOS - PRIMEIRA APRESENTA��O - PASS�VEL DE REAPRESENTA��O: SIM";
                        case 12: return "CHEQUE SEM FUNDOS - SEGUNDA APRESENTA��O - PASS�VEL DE REAPRESENTA��O: N�O ";
                        case 13: return "CONTA ENCERRADA - PASS�VEL DE REAPRESENTA��O: N�O";
                        case 14: return "PR�TICA ESP�RIA - PASS�VEL DE REAPRESENTA��O: N�O";
                        case 20: return "FOLHA DE CHEQUE CANCELADA POR SOLICITA��O DO CORRENTISTA - PASS�VEL DE REAPRESENTA��O: N�O";
                        case 21: return "CONTRA-ORDEM (OU REVOGA��O) OU OPOSI��O (OU SUSTA��O) AO PAGAMENTO PELO EMITENTE OU PELO " +
                                        "PORTADOR - PASS�VEL DE REAPRESENTA��O: SIM";
                        case 22: return "DIVERG�NCIA OU INSUFICI�NCIA DE ASSINATURAb - PASS�VEL DE REAPRESENTA��O: SIM";
                        case 23: return "CHEQUES EMITIDOS POR ENTIDADES E �RG�OS DA ADMINISTRA��O P�BLICA FEDERAL DIRETA E INDIRETA, " +
                                        "EM DESACORDO COM OS REQUISITOS CONSTANTES DO ARTIGO 74, � 2�, DO DECRETO-LEI N� 200, DE 25.02.1967. - " +
                                        "PASS�VEL DE REAPRESENTA��O: SIM";
                        case 24: return "BLOQUEIO JUDICIAL OU DETERMINA��O DO BANCO CENTRAL DO BRASIL - PASS�VEL DE REAPRESENTA��O: SIM";
                        case 25: return "CANCELAMENTO DE TALON�RIO PELO BANCO SACADO - PASS�VEL DE REAPRESENTA��O: N�O";
                        case 28: return "CONTRA-ORDEM (OU REVOGA��O) OU OPOSI��O (OU SUSTA��O) AO PAGAMENTO OCASIONADA POR FURTO OU ROUBO - " +
                                        "PASS�VEL DE REAPRESENTA��O: N�O";
                        case 29: return "CHEQUE BLOQUEADO POR FALTA DE CONFIRMA��O DO RECEBIMENTO DO TALON�RIO PELO CORRENTISTA - " +
                                        "PASS�VEL DE REAPRESENTA��O: SIM";
                        case 30: return "FURTO OU ROUBO DE MALOTES - PASS�VEL DE REAPRESENTA��O: N�O";
                        case 31: return "ERRO FORMAL (SEM DATA DE EMISS�O, COM O M�S GRAFADO NUMERICAMENTE, AUS�NCIA DE ASSINATURA, " +
                                        "N�O-REGISTRO DO VALOR POR EXTENSO) - PASS�VEL DE REAPRESENTA��O: SIM";
                        case 32: return "AUS�NCIA OU IRREGULARIDADE NA APLICA��O DO CARIMBO DE COMPENSA��O - PASS�VEL DE REAPRESENTA��O: SIM";
                        case 33: return "DIVERG�NCIA DE ENDOSSO - PASS�VEL DE REAPRESENTA��O: SIM";
                        case 34: return "CHEQUE APRESENTADO POR ESTABELECIMENTO BANC�RIO QUE N�O O INDICADO NO CRUZAMENTO EM PRETO, SEM O " +
                                        "ENDOSSO-MANDATO - PASS�VEL DE REAPRESENTA��O: SIM";
                        case 35: return "CHEQUE FRAUDADO, EMITIDO SEM PR�VIO CONTROLE OU RESPONSABILIDADE DO ESTABELECIMENTO BANC�RIO " +
                                        "(\"CHEQUE UNIVERSAL\"), OU AINDA COM ADULTERA��O DA PRA�A SACADA - PASS�VEL DE REAPRESENTA��O: N�O";
                        case 36: return "CHEQUE EMITIDO COM MAIS DE UM ENDOSSO - PASS�VEL DE REAPRESENTA��O: SIM";
                        case 40: return "MOEDA INV�LIDA - PASS�VEL DE REAPRESENTA��O: N�O";
                        case 41: return "CHEQUE APRESENTADO A BANCO QUE N�O O SACADO - PASS�VEL DE REAPRESENTA��O: SIM";
                        case 42: return "CHEQUE N�O-COMPENS�VEL NA SESS�O OU SISTEMA DE COMPENSA��O EM QUE FOI APRESENTADO - " +
                                        "PASS�VEL DE REAPRESENTA��O: SIM";
                        case 43: return "CHEQUE, DEVOLVIDO ANTERIORMENTE PELOS MOTIVOS 21, 22, 23, 24, 31 OU 34, N�O-PASS�VEL " +
                                        "DE REAPRESENTA��O EM VIRTUDE DE PERSISTIR O MOTIVO DA DEVOLU��O - PASS�VEL DE REAPRESENTA��O: N�O";
                        case 44: return "CHEQUE PRESCRITO - PASS�VEL DE REAPRESENTA��O: N�O";
                        case 45: return "CHEQUE EMITIDO POR ENTIDADE OBRIGADA A REALIZAR MOVIMENTA��O E UTILIZA��O DE RECURSOS FINANCEIROS " +
                                        "DO TESOURO NACIONAL MEDIANTE ORDEM BANC�RIA - PASS�VEL DE REAPRESENTA��O: N�O";
                        case 48: return "CHEQUE DE VALOR SUPERIOR AO ESTABELECIDO, EMITIDO SEM A IDENTIFICA��O DO BENEFICI�RIO, DEVENDO SER " +
                                        "DEVOLVIDO A QUALQUER TEMPO - PASS�VEL DE REAPRESENTA��O: SIM";
                        case 49: return "REMESSA NULA, CARACTERIZADA PELA REAPRESENTA��O DE CHEQUE DEVOLVIDO PELOS MOTIVOS 12, 13, 14, 20, " +
                                        "25, 28, 30, 35, 43, 44 E 45, PODENDO A SUA DEVOLU��O OCORRER A QUALQUER TEMPO - PASS�VEL DE REAPRESENTA��O: N�O";
                        default: return string.Format("{0:00}-Outros Motivos", CodMotivo);
                    }

                case TipoOcorrencia.RetornoRegistroConfirmado:
                    switch (CodMotivo)
                    {
                        case 1: return "CEP SEM ATENDIMENTO DE PROTESTO NO MOMENTO";
                        default: return string.Format("{0:00}-Outros Motivos", CodMotivo);
                    }

                default: return string.Format("{0:00}-Outros Motivos", CodMotivo);
            }
        }

        /// <summary>
        /// Calculars the digito verificador.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string CalcularDigitoVerificador(Titulo Titulo)
        {
            string Docto = string.Empty;

            if (Titulo.Carteira.IsIn("112", "212", "113", "114", "166", "115", "104", "147", "188", "108",
                "121", "180", "280", "126", "131", "145", "150", "168", "109", "110", "111", "121", "221", "175"))
            {
                Docto = string.Format("{0}{1}", Titulo.Carteira, Titulo.NossoNumero.FillRight(TamanhoMaximoNossoNum, '0'));
            }
            else
            {
                Docto = String.Format("{0}{1}{2}", Titulo.Parent.Cedente.Agencia,
                    Titulo.Parent.Cedente.Conta, Docto);
            }

            Modulo.MultiplicadorInicial = 1;
            Modulo.MultiplicadorFinal = 2;
            Modulo.MultiplicadorAtual = 2;
            Modulo.FormulaDigito = CalcDigFormula.Modulo10;
            Modulo.Documento = Docto;
            Modulo.Calcular();
            return Modulo.DigitoFinal.ToString();
        }

        /// <summary>
        /// Montars the campo codigo cedente.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string MontarCampoCodigoCedente(Titulo Titulo)
        {
            return string.Format(@"{0}/{1}-{2}", Titulo.Parent.Cedente.Agencia,
                Titulo.Parent.Cedente.Conta, Titulo.Parent.Cedente.ContaDigito);
        }

        /// <summary>
        /// Montars the campo nosso numero.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string MontarCampoNossoNumero(Titulo Titulo)
        {
            var NossoNr = Titulo.Carteira + Titulo.NossoNumero.FillRight(TamanhoMaximoNossoNum, '0');
            NossoNr.Insert(3, "/");
            NossoNr.Insert(12, "-");
            return NossoNr + CalcularDigitoVerificador(Titulo);
        }

        /// <summary>
        /// Monta o codigo de barras.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string MontarCodigoBarras(Titulo Titulo)
        {
            var FatorVencimento = Titulo.Vencimento.CalcularFatorVencimento();
            var ANossoNumero = String.Format("{0}{1}{2}", Titulo.Carteira, Titulo.NossoNumero.FillRight(8, '0'),
                CalcularDigitoVerificador(Titulo));
            var aAgenciaCC = String.Format("{0}{1}{2}", Titulo.Parent.Cedente.Agencia,
                Titulo.Parent.Cedente.Conta, Titulo.Parent.Cedente.ContaDigito); 

            var CodigoBarras = string.Format("{0:000}9{1}{2}{3}{4}000", Numero, FatorVencimento,
                       Titulo.ValorDocumento.ToRemessaString(10), ANossoNumero, aAgenciaCC);

            var DigitoCodBarras = CalcularDigitoCodigoBarras(CodigoBarras);
            return CodigoBarras.Insert(4, DigitoCodBarras);
        }

        /// <summary>
        /// Gerars the registro header400.
        /// </summary>
        /// <param name="NumeroRemessa">The numero remessa.</param>
        /// <param name="ARemessa">A remessa.</param>
        /// <exception cref="System.NotImplementedException">Esta fun��o n�o esta implementada para este banco</exception>
        public override void GerarRegistroHeader400(int NumeroRemessa, List<string> ARemessa)
        {
            throw new NotImplementedException("Esta fun��o n�o esta implementada para este banco");
        }

        /// <summary>
        /// Gerars the registro header240.
        /// </summary>
        /// <param name="NumeroRemessa">The numero remessa.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException">Esta fun��o n�o esta implementada para este banco</exception>
        public override string GerarRegistroHeader240(int NumeroRemessa)
        {
            throw new NotImplementedException("Esta fun��o n�o esta implementada para este banco");
        }

        /// <summary>
        /// Gerars the registro transacao400.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <param name="ARemessa">A remessa.</param>
        public override void GerarRegistroTransacao400(Titulo Titulo, List<string> ARemessa)
        {
            
        }

        /// <summary>
        /// Gerars the registro transacao240.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        public override string GerarRegistroTransacao240(Titulo Titulo)
        {
            return string.Empty;
        }

        /// <summary>
        /// Gerars the registro trailler400.
        /// </summary>
        /// <param name="ARemessa">A remessa.</param>
        public override void GerarRegistroTrailler400(List<string> ARemessa)
        {
            
        }

        /// <summary>
        /// Gerars the registro trailler240.
        /// </summary>
        /// <param name="ARemessa">A remessa.</param>
        /// <returns>System.String.</returns>
        public override string GerarRegistroTrailler240(List<string> ARemessa)
        {
            return string.Empty;
        }

        /// <summary>
        /// Lers the retorno400.
        /// </summary>
        /// <param name="ARetorno">A retorno.</param>
        /// <exception cref="System.NotImplementedException">Esta fun��o n�o esta implementada para este banco</exception>
        public override void LerRetorno400(List<string> ARetorno)
        {
            throw new NotImplementedException("Esta fun��o n�o esta implementada para este banco");
        }

        /// <summary>
        /// Lers the retorno240.
        /// </summary>
        /// <param name="ARetorno">A retorno.</param>
        /// <exception cref="System.NotImplementedException">Esta fun��o n�o esta implementada para este banco</exception>
        public override void LerRetorno240(List<string> ARetorno)
        {
            throw new NotImplementedException("Esta fun��o n�o esta implementada para este banco");
        }

        /// <summary>
        /// Calculars the nome arquivo remessa.
        /// </summary>
        /// <returns>System.String.</returns>
        public override string CalcularNomeArquivoRemessa()
        {
            int Sequencia = 0;
            
            if(string.IsNullOrEmpty(Banco.Parent.NomeArqRemessa))
            {
                var NomeFixo = string.Format(@"{0}\cb{1:ddMM}", Banco.Parent.DirArqRemessa, DateTime.Now);
                string NomeArq = string.Empty;
                do
                {
                    Sequencia++;
                    NomeArq = string.Format("{0}{1:00}.rem", NomeFixo, Sequencia);
                }
                while(File.Exists(NomeArq));
                return NomeArq;
            }
            else
             return string.Format(@"{0}\{1}",  Banco.Parent.DirArqRemessa, Banco.Parent.NomeArqRemessa);
        }

        /// <summary>
        /// Calculars the digito codigo barras.
        /// </summary>
        /// <param name="CodigoBarras">The codigo barras.</param>
        /// <returns>System.String.</returns>
        protected override string CalcularDigitoCodigoBarras(string CodigoBarras)
        {
            Modulo.CalculoPadrao();
            Modulo.Documento = CodigoBarras;
            Modulo.Calcular();

            if (Modulo.DigitoFinal == 0 || Modulo.DigitoFinal > 9)
                return "1";
            else
                return Modulo.DigitoFinal.ToString();
        }

        #endregion Methods
    }
}