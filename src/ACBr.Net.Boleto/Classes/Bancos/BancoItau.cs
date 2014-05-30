// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 05-08-2014
//
// Last Modified By : RFTD
// Last Modified On : 05-23-2014
// ***********************************************************************
// <copyright file="BancoItau.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
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
    /// Classe BancoItau. Esta classe n�o pode ser herdada.
    /// </summary>
    public sealed class BancoItau : BancoBase
    {
        #region Fields
        #endregion Fields

        #region Constructor

        /// <summary>
        /// Inicializa uma nova instancia da classe <see cref="BancoItau" />.
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
            string Docto;
            if (Titulo.Carteira.IsIn("112", "212", "113", "114", "166", "115", "104", "147", "188", "108",
                "121", "180", "280", "126", "131", "145", "150", "168", "109", "110", "111", "121", "221", "175"))
            {
                Docto = string.Format("{0}{1}", Titulo.Carteira, Titulo.NossoNumero.FillRight(TamanhoMaximoNossoNum, '0'));
            }
            else
            {
                Docto = String.Format("{0}{1}{2}{3}", Titulo.Parent.Cedente.Agencia,
                    Titulo.Parent.Cedente.Conta, Titulo.Carteira, Titulo.NossoNumero.FillRight(TamanhoMaximoNossoNum, '0'));
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
			var cedente = Banco.Parent.Cedente;
			var wLinha = new StringBuilder();

			//GERAR REGISTRO-HEADER DO ARQUIVO
			wLinha.Append("0");                                   // 1 a 1     - IDENTIFICA��O DO REGISTRO HEADER
			wLinha.Append("1");                                   // 2 a 2     - TIPO DE OPERA��O - REMESSA
			wLinha.Append("REMESSA");                             // 3 a 9     - IDENTIFICA��O POR EXTENSO DO MOVIMENTO
			wLinha.Append("01");                                  // 10 a 11   - IDENTIFICA��O DO TIPO DE SERVI�O
			wLinha.Append("COBRANCA".FillLeft(15));               // 12 a 26   - IDENTIFICA��O POR EXTENSO DO TIPO DE SERVI�O
			wLinha.Append(cedente.Agencia.ZeroFill(4));           // 27 a 30   - AG�NCIA MANTENEDORA DA CONTA
			wLinha.Append("00");                                  // 31 a 32   - COMPLEMENTO DE REGISTRO
			wLinha.Append(cedente.Conta.ZeroFill(5));             // 33 a 37   - N�MERO DA CONTA CORRENTE DA EMPRESA
			wLinha.Append(cedente.ContaDigito.ZeroFill(1));       // 38 a 38   - D�GITO DE AUTO CONFER�NCIA AG/CONTA EMPRESA
			wLinha.Append("".FillLeft(8));                        // 39 a 46   - COMPLEMENTO DO REGISTRO
			wLinha.Append(cedente.Nome.FillLeft(30));             // 47 a 76   - NOME POR EXTENSO DA "EMPRESA M�E"
			wLinha.AppendFormat("{0:000}", Banco.Numero);         // 77 a 79   - N� DO BANCO NA C�MARA DE COMPENSA��O
			wLinha.Append("BANCO ITAU SA".FillLeft(15));          // 80 a 94   - NOME POR EXTENSO DO BANCO COBRADOR
			wLinha.AppendFormat("{0:ddMMyy}", DateTime.Now);      // 95 a 100  - DATA DE GERA��O DO ARQUIVO
			wLinha.Append("".FillLeft(294));                      // 101 a 394 - COMPLEMENTO DO REGISTRO
			wLinha.Append("1".ZeroFill(6));                       // 395 a 400 - N�MERO SEQ�ENCIAL DO REGISTRO NO ARQUIVO
			
			ARemessa.Add(wLinha.ToString().ToUpper());
		}

        /// <summary>
        /// Gera o registro header240.
        /// </summary>
        /// <param name="NumeroRemessa">The numero remessa.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException">Esta fun��o n�o esta implementada para este banco</exception>
        public override string GerarRegistroHeader240(int NumeroRemessa)
        {
			string ATipoInscricao;
			switch (Banco.Parent.Cedente.TipoInscricao)
			{
				case PessoaCedente.Fisica: ATipoInscricao = "1"; break;
				default: ATipoInscricao = "2"; break;
			}

			var cedente = Banco.Parent.Cedente;
			var Result = new StringBuilder();

			//GERAR REGISTRO-HEADER DO ARQUIVO
			Result.AppendFormat("{0:000}", Banco.Numero);		//1 a 3 - C�digo do banco
			Result.Append("0000");								//4 a 7 - Lote de servi�o
			Result.Append("0");									//8 - Tipo de registro - Registro header de arquivo
            Result.Append("".FillLeft(9));						//9 a 17 Uso exclusivo FEBRABAN/CNAB
            Result.Append(ATipoInscricao);						//18 - Tipo de inscri��o do cedente
            Result.Append(cedente.CNPJCPF.ZeroFill(14));		//19 a 32 -N�mero de inscri��o do cedente
            Result.Append("".FillLeft(20));						//33 a 52 - Brancos
            Result.Append("0");									//53 - Zeros
            Result.Append(cedente.Agencia.ZeroFill(4));			//54 a 57 - C�digo da ag�ncia do cedente
            Result.Append(" ");									//58 - Brancos
            Result.Append("0000000");							//59 a 65 - Zeros
            Result.Append(cedente.Conta.ZeroFill(5));			//66 a 70 - N�mero da conta do cedente
            Result.Append(" ");									//71 - Branco
            Result.Append(cedente.ContaDigito.ZeroFill(1));		//72 - D�gito da conta do cedente
            Result.Append(cedente.Nome.FillLeft(30));			//73 a 102 - Nome do cedente
            Result.Append("BANCO ITAU SA".PadLeft(30));			//103 a 132 - Nome do banco
            Result.Append("".FillLeft(10));						//133 A 142 - Brancos
            Result.Append("1");                                 //143 - C�digo de Remessa (1) / Retorno (2)
            Result.AppendFormat("{0:ddMMyyyy}", DateTime.Now);  //144 a 151 - Data do de gera��o do arquivo
            Result.AppendFormat("{0:hhmmss}", DateTime.Now);    //152 a 157 - Hora de gera��o do arquivo
			Result.Append("000000");                            //158 a 163 - N�mero sequencial do arquivo retorno
            Result.Append("040");                               //164 a 166 - N�mero da vers�o do layout do arquivo
            Result.Append("00000");                             //167 a 171 - Zeros
            Result.Append("".FillLeft(54));                     //172 a 225 - 54 Brancos
            Result.Append("000");                               //226 a 228 - zeros
            Result.Append("".FillLeft(12));                     //229 a 240 - Brancos

			//GERAR REGISTRO HEADER DO LOTE
			Result.Append(Environment.NewLine);
			Result.AppendFormat("{0:000}", Banco.Numero);		//1 a 3 - C�digo do banco
            Result.Append("0001");                              //4 a 7 - Lote de servi�o
            Result.Append("1");                                 //8 - Tipo de registro - Registro header de arquivo
            Result.Append("R");                                 //9 - Tipo de opera��o: R (Remessa) ou T (Retorno)
            Result.Append("01");                                //10 a 11 - Tipo de servi�o: 01 (Cobran�a)
            Result.Append("00");                                //12 a 13 - Forma de lan�amento: preencher com ZEROS no caso de cobran�a
            Result.Append("030");                               //14 a 16 - N�mero da vers�o do layout do lote
            Result.Append(" ");                                 //17 - Uso exclusivo FEBRABAN/CNAB
            Result.Append(ATipoInscricao);                      //18 - Tipo de inscri��o do cedente
            Result.Append(cedente.CNPJCPF.ZeroFill(15));        //19 a 33 -N�mero de inscri��o do cedente
            Result.Append("".FillLeft(20));                     //34 a 53 - Brancos
            Result.Append("0");                                 //54 - Zeros
            Result.Append(cedente.Agencia.ZeroFill(4));         //55 a 58 - C�digo da ag�ncia do cedente
            Result.Append(" ");                                 //59
            Result.Append("0000000");                           //60 a 66
            Result.Append(cedente.Conta.ZeroFill(5));           //67 a 71 - N�mero da conta do cedente
            Result.Append(" ");                                 //72
            Result.Append(cedente.ContaDigito);                 //73 - D�gito verificador da ag�ncia / conta
			Result.Append(cedente.Nome.FillLeft(30));           //74 a 103 - Nome do cedente
            Result.Append("".FillLeft(80));                     //104 a 183 - Brancos
            Result.Append("00000000");                          //184 a 191 - N�mero sequ�ncia do arquivo retorno.
            Result.AppendFormat("{0:ddMMyyyy}", DateTime.Now);  //192 a 199 - Data de gera��o do arquivo
            Result.Append("".ZeroFill(8));                      //200 a 207 - Data do cr�dito - S� para arquivo retorno
            Result.Append("".FillLeft(33));                     //208 a 240 - Uso exclusivo FEBRABAN/CNAB

			return Result.ToString().ToUpper();
        }

        /// <summary>
        /// Gerars the registro transacao400.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <param name="ARemessa">A remessa.</param>
        public override void GerarRegistroTransacao400(Titulo Titulo, List<string> ARemessa)
        {
			var DoMontaInstrucoes1 = new Func<string>(() =>
			{
				if (Titulo.Mensagem.Count < 1)
					return string.Empty;

				var Result = new StringBuilder();
				Result.Append(Environment.NewLine); 
				Result.Append("6");                                         // IDENTIFICA��O DO REGISTRO
				Result.Append("2");                                         // IDENTIFICA��O DO LAYOUT PARA O REGISTRO
				Result.Append(Titulo.Mensagem[0].FillLeft(69));             // CONTE�DO DA 1� LINHA DE IMPRESS�O DA �REA "INSTRU��ES� DO BOLETO
				
				if(Titulo.Mensagem.Count >= 2)
					Result.Append(Titulo.Mensagem[1].FillLeft(69));         // CONTE�DO DA 2� LINHA DE IMPRESS�O DA �REA "INSTRU��ES� DO BOLETO
				else
				    Result.Append("".FillLeft(69));                         // CONTE�DO DO RESTANTE DAS LINHAS
				
				if(Titulo.Mensagem.Count >= 3)
					Result.Append(Titulo.Mensagem[2].FillLeft(69));         // CONTE�DO DA 3� LINHA DE IMPRESS�O DA �REA "INSTRU��ES� DO BOLETO
				else
				    Result.Append("".FillLeft(69));                         // CONTE�DO DO RESTANTE DAS LINHAS
				
				if(Titulo.Mensagem.Count >= 4)
					Result.Append(Titulo.Mensagem[3].FillLeft(69));         // CONTE�DO DA 4� LINHA DE IMPRESS�O DA �REA "INSTRU��ES� DO BOLETO
				else
				    Result.Append("".FillLeft(69));                         // CONTE�DO DO RESTANTE DAS LINHAS
				
				if(Titulo.Mensagem.Count >= 5)
					Result.Append(Titulo.Mensagem[4].FillLeft(69));         // CONTE�DO DA 5� LINHA DE IMPRESS�O DA �REA "INSTRU��ES� DO BOLETO
				else
				    Result.Append("".FillLeft(69));                         // CONTE�DO DO RESTANTE DAS LINHAS

				Result.Append("".FillLeft(47));                             // COMPLEMENTO DO REGISTRO
				Result.AppendFormat("{0:000000}", ARemessa.Count + 2);      // N� SEQ�ENCIAL DO REGISTRO NO ARQUIVO

				return Result.ToString().ToUpper();
			});

			//Pegando o Tipo de Ocorrencia
			string ATipoOcorrencia;
			switch (Titulo.OcorrenciaOriginal.Tipo)
			{
				case TipoOcorrencia.RemessaBaixar: ATipoOcorrencia = "02"; break;
				case TipoOcorrencia.RemessaConcederAbatimento: ATipoOcorrencia = "04"; break;
				case TipoOcorrencia.RemessaCancelarAbatimento: ATipoOcorrencia = "05"; break;
				case TipoOcorrencia.RemessaAlterarVencimento: ATipoOcorrencia = "06"; break;
				case TipoOcorrencia.RemessaAlterarUsoEmpresa: ATipoOcorrencia = "07"; break;
				case TipoOcorrencia.RemessaAlterarSeuNumero: ATipoOcorrencia = "08"; break;
				case TipoOcorrencia.RemessaProtestar: ATipoOcorrencia = "09"; break;
				case TipoOcorrencia.RemessaNaoProtestar: ATipoOcorrencia = "10"; break;
				case TipoOcorrencia.RemessaProtestoFinsFalimentares: ATipoOcorrencia = "11"; break;
				case TipoOcorrencia.RemessaSustarProtesto: ATipoOcorrencia = "18"; break;
				case TipoOcorrencia.RemessaOutrasAlteracoes: ATipoOcorrencia = "31"; break;
				case TipoOcorrencia.RemessaBaixaporPagtoDiretoCedente: ATipoOcorrencia = "34"; break;
				case TipoOcorrencia.RemessaCancelarInstrucao: ATipoOcorrencia = "35"; break;
				case TipoOcorrencia.RemessaAlterarVencSustarProtesto: ATipoOcorrencia = "37"; break;
				case TipoOcorrencia.RemessaCedenteDiscordaSacado: ATipoOcorrencia = "38"; break;
				case TipoOcorrencia.RemessaCedenteSolicitaDispensaJuros: ATipoOcorrencia = "47"; break;
				default: ATipoOcorrencia = "01"; break;
			}

			//Pegando o Aceite do Titulo
			string ATipoAceite;
			switch (Titulo.Aceite)
			{
				case AceiteTitulo.Nao: ATipoAceite = "N"; break;
				default: ATipoAceite = "A"; break;
			}

			//Pegando o tipo de EspecieDoc
			string ATipoEspecieDoc = string.Empty;
			if (Titulo.EspecieDoc.Trim() == "DM")
				ATipoEspecieDoc = "01";
			else if (Titulo.EspecieDoc.Trim() == "NP")
				ATipoEspecieDoc = "02";
			else if (Titulo.EspecieDoc.Trim() == "NS")
				ATipoEspecieDoc = "03";
			else if (Titulo.EspecieDoc.Trim() == "ME")
				ATipoEspecieDoc = "04";
			else if (Titulo.EspecieDoc.Trim() == "RC")
				ATipoEspecieDoc = "05";
			else if (Titulo.EspecieDoc.Trim() == "CT")
				ATipoEspecieDoc = "06";
			else if (Titulo.EspecieDoc.Trim() == "CS")
				ATipoEspecieDoc = "07";
			else if (Titulo.EspecieDoc.Trim() == "DS")
				ATipoEspecieDoc = "08";
			else if (Titulo.EspecieDoc.Trim() == "LC")
				ATipoEspecieDoc = "09";
			else if (Titulo.EspecieDoc.Trim() == "ND")
				ATipoEspecieDoc = "13";
			else if (Titulo.EspecieDoc.Trim() == "DD")
				ATipoEspecieDoc = "15";
			else if (Titulo.EspecieDoc.Trim() == "EC")
				ATipoEspecieDoc = "16";
			else if (Titulo.EspecieDoc.Trim() == "PS")
				ATipoEspecieDoc = "17";
			else if (Titulo.EspecieDoc.Trim() == "DV")
				ATipoEspecieDoc = "99";

			//Mora Juros
			string ADataMoraJuros;
			if (Titulo.ValorMoraJuros > 0)
			{
				if (Titulo.DataMoraJuros.HasValue)
					ADataMoraJuros = string.Format("{0:ddMMyyyy}", Titulo.DataMoraJuros);
				else
					ADataMoraJuros = "".ZeroFill(8);
			}
			else
				ADataMoraJuros = "".ZeroFill(8);

			//Descontos
			string ADataDesconto;
			if (Titulo.ValorDesconto > 0)
			{
				if (Titulo.DataDesconto.HasValue)
					ADataDesconto = string.Format("{0:ddMMyyyy}", Titulo.DataDesconto);
				else
					ADataDesconto = "".ZeroFill(8);
			}
			else
				ADataDesconto = "".ZeroFill(8);

			//Pegando Tipo Cendete
			string ATipoCedente;
			switch(Titulo.Parent.Cedente.TipoInscricao)
			{
                case PessoaCedente.Fisica: ATipoCedente = "01"; break;
                default: ATipoCedente = "02"; break;
			}

			//Pegando Tipo de Sacado
			string ATipoSacado;
			switch (Titulo.Sacado.Pessoa)
			{
				case Pessoa.Fisica: ATipoSacado = "01"; break;
				case Pessoa.Juridica: ATipoSacado = "02"; break;
				default: ATipoSacado = "99"; break;
			}

			//endereco
			string end = string.Format("{0} {1} {2}", Titulo.Sacado.Logradouro, 
					Titulo.Sacado.Numero, Titulo.Sacado.Complemento).FillLeft(40);

			var wLinha = new StringBuilder();

			//Cobran�a sem registro com op��o de envio de arquivo remessa
			if (Titulo.Carteira.Trim().IsIn("102", "103", "107", "172", "173", "196"))
			{
				string ANossoNumero = Banco.MontarCampoNossoNumero(Titulo);		

				wLinha.Append("6");                                                               // 6 - FIXO
                wLinha.Append("1");                                                               // 1 - FIXO
                wLinha.Append(Titulo.Parent.Cedente.Agencia.ZeroFill(4));                         // AG�NCIA MANTENEDORA DA CONTA
                wLinha.Append("00");                                                              // COMPLEMENTO DE REGISTRO
                wLinha.Append(Titulo.Parent.Cedente.Conta.ZeroFill(5));                           // N�MERO DA CONTA CORRENTE DA EMPRESA
                wLinha.Append(Titulo.Parent.Cedente.ContaDigito.ZeroFill(1));                     // D�GITO DE AUTO CONFER�NCIA AG/CONTA EMPRESA
                wLinha.Append(Titulo.Carteira.Trim());                                            // N�MERO DA CARTEIRA NO BANCO
                wLinha.Append(Titulo.NossoNumero.ZeroFill(8));                                    // IDENTIFICA��O DO T�TULO NO BANCO
                wLinha.Append(ANossoNumero[ANossoNumero.Length-1]);					              // DAC DO NOSSO N�MERO
                wLinha.Append("0");                                                               // 0 - R$
                wLinha.Append("R$".FillLeft(4));                                                  // LITERAL DE MOEDA
                wLinha.Append(Titulo.ValorDocumento.ToRemessaString(13));                         // VALOR NOMINAL DO T�TULO
                wLinha.Append(Titulo.SeuNumero.FillLeft(10));                                     // IDENTIFICA��O DO T�TULO NA EMPRESA
                wLinha.AppendFormat("{0:ddMMyy}", Titulo.Vencimento);                             // DATA DE VENCIMENTO DO T�TULO
				wLinha.Append(ATipoEspecieDoc.ZeroFill(2));                                       // ESP�CIE DO T�TULO
				wLinha.Append(ATipoAceite);                                                       // IDENTIFICA��O DE TITILO ACEITO OU N�O ACEITO
                wLinha.AppendFormat("{0:ddMMyy}", Titulo.DataDocumento);                          // DATA DE EMISS�O
                   
				//Dados do sacado
                wLinha.Append(ATipoSacado);                                                       // IDENTIFICA��O DO TIPO DE INSCRI��O/SACADO
                wLinha.Append(Titulo.Sacado.CNPJCPF.ZeroFill(15));                                // N� DE INSCRI��O DO SACADO  (CPF/CGC)
                wLinha.Append(Titulo.Sacado.NomeSacado.FillLeft(30));                             // NOME DO SACADO
                wLinha.Append("".FillLeft(9));                                                    // BRANCOS(COMPLEMENTO DE REGISTRO)
                wLinha.Append(end);																  // RUA, N�MERO E COMPLEMENTO DO SACADO
                wLinha.Append(Titulo.Sacado.Bairro.FillLeft(12));                                 // BAIRRO DO SACADO
                wLinha.Append(Titulo.Sacado.CEP.OnlyNumbers().ZeroFill(8));                       // CEP DO SACADO
                wLinha.Append(Titulo.Sacado.Cidade.FillLeft(15));                                 // CIDADE DO SACADO
                wLinha.Append(Titulo.Sacado.UF.FillLeft(2));                                      // UF DO SACADO
                  
				   //Dados do sacador/avalista}
                 wLinha.Append("".FillLeft(30));                                                  // NOME DO SACADOR/AVALISTA
                 wLinha.Append("".FillLeft(4));                                                   // COMPLEMENTO DO REGISTRO
                 wLinha.Append(Titulo.LocalPagamento.FillLeft(55));                               // LOCAL PAGAMENTO
                 wLinha.Append("".FillLeft(51));                                                  // LOCAL PAGAMENTO 2
                 wLinha.Append("01");                                                             // IDENTIF. TIPO DE INSCRI��O DO SACADOR/AVALISTA
                 wLinha.Append("".ZeroFill(15));                                                  // N�MERO DE INSCRI��O DO SACADOR/AVALISTA
                 wLinha.Append("".FillLeft(31));                                                  // COMPLEMENTO DO REGISTRO
                 wLinha.AppendFormat("{0:000000}", ARemessa.Count + 1);

				wLinha.Append(DoMontaInstrucoes1());
			}
			else
			{
				//Carteira com registro
				wLinha.Append("1");                                                               // 1 a 1 - IDENTIFICA��O DO REGISTRO TRANSA��O
                wLinha.Append(ATipoCedente);                                                      // TIPO DE INSCRI��O DA EMPRESA
				wLinha.Append(Titulo.Parent.Cedente.CNPJCPF.OnlyNumbers().ZeroFill(14));          // N� DE INSCRI��O DA EMPRESA (CPF/CGC)
				wLinha.Append(Titulo.Parent.Cedente.Agencia.OnlyNumbers().ZeroFill(4));           // AG�NCIA MANTENEDORA DA CONTA
				wLinha.Append("00");                                                              // COMPLEMENTO DE REGISTRO
				wLinha.Append(Titulo.Parent.Cedente.Conta.OnlyNumbers().ZeroFill(5));             // N�MERO DA CONTA CORRENTE DA EMPRESA
				wLinha.Append(Titulo.Parent.Cedente.ContaDigito.OnlyNumbers().ZeroFill(1));       // D�GITO DE AUTO CONFER�NCIA AG/CONTA EMPRESA
				wLinha.Append("".FillLeft(4));                                                    // COMPLEMENTO DE REGISTRO
				wLinha.Append("0000");                                                            // C�D.INSTRU��O/ALEGA��O A SER CANCELADA
				wLinha.Append(Titulo.SeuNumero.FillLeft(25));                                     // IDENTIFICA��O DO T�TULO NA EMPRESA
				wLinha.Append(Titulo.NossoNumero.ZeroFill(8));                                    // IDENTIFICA��O DO T�TULO NO BANCO
				wLinha.Append("0000000000000");                                                   // QUANTIDADE DE MOEDA VARI�VEL
				wLinha.Append(Titulo.Carteira);                                                   // N�MERO DA CARTEIRA NO BANCO
				wLinha.Append("".FillLeft(21));                                                   // IDENTIFICA��O DA OPERA��O NO BANCO
                wLinha.Append("I");                                                               // C�DIGO DA CARTEIRA
                wLinha.Append(ATipoOcorrencia);                                                   // IDENTIFICA��O DA OCORR�NCIA
                wLinha.Append(Titulo.NumeroDocumento.FillLeft(10));                               // N� DO DOCUMENTO DE COBRAN�A (DUPL.,NP ETC.)
                wLinha.AppendFormat("{0:ddMMyy}", Titulo.Vencimento);                             // DATA DE VENCIMENTO DO T�TULO
                wLinha.Append(Titulo.ValorDocumento.ToRemessaString());                           // VALOR NOMINAL DO T�TULO
				wLinha.AppendFormat("{0:000}", Banco.Numero);                                     // N� DO BANCO NA C�MARA DE COMPENSA��O
                wLinha.Append("00000");                                                           // AG�NCIA ONDE O T�TULO SER� COBRADO
                wLinha.Append(ATipoEspecieDoc.ZeroFill(2));                                       // ESP�CIE DO T�TULO
                wLinha.Append(ATipoAceite);                                                       // IDENTIFICA��O DE TITILO ACEITO OU N�O ACEITO
                wLinha.AppendFormat("{0:ddMMyy}", Titulo.DataDocumento);                          // DATA DA EMISS�O DO T�TULO
                wLinha.Append(Titulo.Instrucao1.Trim().ZeroFill(2));                              // 1� INSTRU��O
                wLinha.Append(Titulo.Instrucao2.Trim().ZeroFill(2));                              // 2� INSTRU��O
                wLinha.Append(Titulo.ValorMoraJuros.ToRemessaString());                           // VALOR DE MORA POR DIA DE ATRASO
                wLinha.Append(ADataDesconto);                                                     // DATA LIMITE PARA CONCESS�O DE DESCONTO
				wLinha.Append(Titulo.ValorDesconto > 0 ? Titulo.ValorDesconto.ToRemessaString() :
                         "".ZeroFill(13));                                                        // VALOR DO DESCONTO A SER CONCEDIDO
                wLinha.Append(Titulo.ValorIOF.ToRemessaString());                                 // VALOR DO I.O.F. RECOLHIDO P/ NOTAS SEGURO
                wLinha.Append(Titulo.ValorAbatimento.ToRemessaString());                          // VALOR DO ABATIMENTO A SER CONCEDIDO

                   //Dados do sacado
                wLinha.Append(ATipoSacado);                                                       // IDENTIFICA��O DO TIPO DE INSCRI��O/SACADO
                wLinha.Append(Titulo.Sacado.CNPJCPF.OnlyNumbers().ZeroFill(14));                  // N� DE INSCRI��O DO SACADO  (CPF/CGC)
                wLinha.Append(Titulo.Sacado.NomeSacado.FillLeft(30));                             // NOME DO SACADO
                wLinha.Append("".FillLeft(10));                                                   // BRANCOS(COMPLEMENTO DE REGISTRO)
                wLinha.Append(end);																  // RUA, N�MERO E COMPLEMENTO DO SACADO
                wLinha.Append(Titulo.Sacado.Bairro.FillLeft(12));                                 // BAIRRO DO SACADO
                wLinha.Append(Titulo.Sacado.CEP.OnlyNumbers().ZeroFill(8));                       // CEP DO SACADO
                wLinha.Append(Titulo.Sacado.Cidade.FillLeft(15));                                 // CIDADE DO SACADO
                wLinha.Append(Titulo.Sacado.UF.FillLeft(2));                                      // UF DO SACADO

                   //Dados do sacador/avalista
                wLinha.Append("".FillLeft(30));                                                   // NOME DO SACADOR/AVALISTA
                wLinha.Append("".FillLeft(4));                                                    // COMPLEMENTO DO REGISTRO
                wLinha.Append(ADataMoraJuros);                                                    // DATA DE MORA
                wLinha.Append(Titulo.DataProtesto.HasValue && Titulo.DataProtesto > Titulo.Vencimento ?
					Titulo.DataProtesto.Value.Date.Subtract(Titulo.Vencimento.Date).Days.ToString("00") :
				    "00");                                                                        // PRAZO
                wLinha.Append("".FillLeft(1));                                                    // BRANCOS
                wLinha.AppendFormat("{0:000000}", ARemessa.Count + 1);
			}

			ARemessa.Add(wLinha.ToString().ToUpper());

        }

        /// <summary>
        /// Gerars the registro transacao240.
        /// </summary>
        /// <param name="Titulo">The titulo.</param>
        /// <returns>System.String.</returns>
		public override string GerarRegistroTransacao240(Titulo Titulo)
		{
			//Pegando o Tipo de Ocorrencia
			string ATipoOcorrencia;
			switch (Titulo.OcorrenciaOriginal.Tipo)
			{
				case TipoOcorrencia.RemessaBaixar: ATipoOcorrencia = "02"; break;
				case TipoOcorrencia.RemessaConcederAbatimento: ATipoOcorrencia = "04"; break;
				case TipoOcorrencia.RemessaCancelarAbatimento: ATipoOcorrencia = "05"; break;
				case TipoOcorrencia.RemessaAlterarVencimento: ATipoOcorrencia = "06"; break;
				case TipoOcorrencia.RemessaSustarProtesto: ATipoOcorrencia = "18"; break;
				case TipoOcorrencia.RemessaCancelarInstrucaoProtesto: ATipoOcorrencia = "10"; break;
				default: ATipoOcorrencia = "01"; break;
			}

			//Pegando o Aceite do Titulo
			string ATipoAceite;
			switch (Titulo.Aceite)
			{
				case AceiteTitulo.Nao: ATipoAceite = "N"; break;
				default: ATipoAceite = "A"; break;
			}

			//Mora Juros
			string ADataMoraJuros;
			if (Titulo.ValorMoraJuros > 0)
			{
				if (Titulo.DataMoraJuros.HasValue)
					ADataMoraJuros = string.Format("{0:ddMMyyyy}", Titulo.DataMoraJuros);
				else
					ADataMoraJuros = "".ZeroFill(8);
			}
			else
				ADataMoraJuros = "".ZeroFill(8);

			//Descontos
			string ADataDesconto;
			if (Titulo.ValorDesconto > 0)
			{
				if (Titulo.DataDesconto.HasValue)
					ADataDesconto = string.Format("{0:ddMMyyyy}", Titulo.DataDesconto);
				else
					ADataDesconto = "".ZeroFill(8);
			}
			else
				ADataDesconto = "".ZeroFill(8);

			//Index boleto
			string AIndex = string.Format("{0:00000}", Titulo.Parent.ListadeBoletos.IndexOf(Titulo) + 1);

			//Data Protesto
			string ADataProtesto;
			if (Titulo.DataProtesto.HasValue && Titulo.DataProtesto > Titulo.Vencimento)
				ADataProtesto = string.Format("{0:dd}", Titulo.DataProtesto.Value.Date.Subtract(Titulo.Vencimento.Date));
			else
				ADataProtesto = "00";

			var Result = new StringBuilder();
			Result.AppendFormat("{0:000}", Banco.Numero);						   //1 a 3 - C�digo do banco
			Result.Append("0001");                                                 //4 a 7 - Lote de servi�o
			Result.Append("3");                                                    //8 - Tipo do registro: Registro detalhe
			Result.Append(AIndex);												   //9 a 13 - N�mero seq�encial do registro no lote - Cada registro possui dois segmentos
			Result.Append("P");                                                    //14 - C�digo do segmento do registro detalhe
			Result.Append(" ");                                                    //15 - Uso exclusivo FEBRABAN/CNAB: Branco
			Result.Append(ATipoOcorrencia);                                        //16 a 17 - C�digo de movimento
			Result.Append("0");                                                    //18
			Result.Append(Titulo.Parent.Cedente.Agencia.ZeroFill(4));              //19 a 22 - Ag�ncia mantenedora da conta
			Result.Append(" ");                                                    //23
			Result.Append("0000000");                                              //24 a 30 - Complemento de Registro
			Result.Append(Titulo.Parent.Cedente.Conta.ZeroFill(5));				   //31 a 35 - N�mero da Conta Corrente
			Result.Append(" ");                                                    //36
			Result.Append(Titulo.Parent.Cedente.ContaDigito);                      //37 - D�gito verificador da ag�ncia / conta
			Result.Append(Titulo.Carteira);                                        //38 a 40 - Carteira
			Result.Append(Titulo.NossoNumero.ZeroFill(8));                         //41 a 48 - Nosso n�mero - identifica��o do t�tulo no banco
			Result.Append(CalcularDigitoVerificador(Titulo));                      //49 - D�gito verificador da ag�ncia / conta preencher somente em cobran�a sem registro
			Result.Append("".FillLeft(8));                                         //50 a 57 - Brancos
			Result.Append("".ZeroFill(5));                                         //58 a 62 - Complemento
			Result.Append(Titulo.NumeroDocumento.FillLeft(10));                    //63 a 72 - N�mero que identifica o t�tulo na empresa [ Alterado conforme instru��es da CSO Bras�lia ] {27-07-09}
			Result.Append("".FillLeft(5));                                         //73 a 77 - Brancos
			Result.AppendFormat("{0:ddMMyyyy}", Titulo.Vencimento);                //78 a 85 - Data de vencimento do t�tulo
			Result.Append(Titulo.ValorDocumento.ToRemessaString(15));              //86 a 100 - Valor nominal do t�tulo
			Result.Append("00000");                                                //101 a 105 - Ag�ncia cobradora. // Ficando com Zeros o Ita� definir� a ag�ncia cobradora pelo CEP do sacado
			Result.Append(" ");                                                    //106 - D�gito da ag�ncia cobradora
			Result.Append(Titulo.EspecieDoc.FillLeft(2));                                                  // 107 a 108 - Esp�cie do documento
			Result.Append(ATipoAceite);											   //109 - Identifica��o de t�tulo Aceito / N�o aceito
			Result.AppendFormat("{0:ddMMyyyy}", Titulo.DataDocumento);             //110 a 117 - Data da emiss�o do documento
			Result.Append("0");                                                    //118 - Zeros
			Result.Append(ADataMoraJuros);                                         //119 a 126 - Data a partir da qual ser�o cobrados juros
			Result.Append(Titulo.ValorMoraJuros > 0 ?
				Titulo.ValorMoraJuros.ToRemessaString(15) : "".ZeroFill(15));      //127 a 141 - Valor de juros de mora por dia
			Result.Append("0");                                                    //142 - Zeros
			Result.Append(ADataDesconto);                                          //143 a 150 - Data limite para desconto
			Result.Append(Titulo.ValorDesconto > 0 ?
				Titulo.ValorDesconto.ToRemessaString(15) : "".ZeroFill(15));       //151 a 165 - Valor do desconto por dia
			Result.Append(Titulo.ValorIOF.ToRemessaString(15));                    //166 a 180 - Valor do IOF a ser recolhido
			Result.Append(Titulo.ValorAbatimento.ToRemessaString(15));             //181 a 195 - Valor do abatimento
			Result.Append(Titulo.SeuNumero.FillLeft(25));                          //196 a 220 - Identifica��o do t�tulo na empresa
			Result.Append(Titulo.DataProtesto.HasValue &&
				Titulo.DataProtesto > Titulo.Vencimento ? "1" : "3");			   //221 - C�digo de protesto: Protestar em XX dias corridos
			Result.Append(ADataProtesto);										   //222 a 223 - Prazo para protesto (em dias corridos)
			Result.Append("0");                                                    //224 - C�digo de Baixa
			Result.Append("00");                                                   //225 A 226 - Dias para baixa
			Result.Append("0000000000000 ");

			//SEGMENTO Q
			string ATipoInscricao;
			switch (Titulo.Sacado.Pessoa)
			{
				case Pessoa.Fisica: ATipoInscricao = "1"; break;
				case Pessoa.Juridica: ATipoInscricao = "2"; break;
				default: ATipoInscricao = "9"; break;
			}

			//Endereco sacado
			string SEndereco = string.Format("{0} {1} {2}", Titulo.Sacado.Logradouro,
				Titulo.Sacado.Numero, Titulo.Sacado.Complemento).FillLeft(40);

			Result.Append(Environment.NewLine);
			Result.AppendFormat("{0:000}", Banco.Numero);				    //1 a 3 - C�digo do banco
			Result.Append("0001");                                          //N�mero do lote
            Result.Append("3");                                             //Tipo do registro: Registro detalhe
            Result.Append(AIndex);											//N�mero seq�encial do registro no lote - Cada registro possui dois segmentos
            Result.Append("Q");                                             //C�digo do segmento do registro detalhe
            Result.Append(" ");                                             //Uso exclusivo FEBRABAN/CNAB: Branco
            Result.Append("01");                                            //16 a 17
            
		    //Dados do sacado}
            Result.Append(ATipoInscricao);                                  //18 a 18 Tipo inscricao
            Result.Append(Titulo.Sacado.CNPJCPF.ZeroFill(15));              //19 a 33
            Result.Append(Titulo.Sacado.NomeSacado.FillLeft(30));           //34 a 63
            Result.Append("".FillLeft(10));                                 //64 a 73
            Result.Append(SEndereco);  // 74 a 113
            Result.Append(Titulo.Sacado.Bairro.FillLeft(15));               //114 a 128
            Result.Append(Titulo.Sacado.CEP.ZeroFill(8));                   //129 a 136
            Result.Append(Titulo.Sacado.Cidade.FillLeft(15));               //137 a 151
            Result.Append(Titulo.Sacado.UF.FillLeft(2));                    //152 a 153
            
			//Dados do sacador/avalista}
            Result.Append("0");                                             //Tipo de inscri��o: N�o informado
            Result.Append("".ZeroFill(15));                                 //N�mero de inscri��o
            Result.Append("".FillLeft(30));                                 //Nome do sacador/avalista
            Result.Append("".FillLeft(10));                                 //Uso exclusivo FEBRABAN/CNAB
            Result.Append("".ZeroFill(3));                                  //Uso exclusivo FEBRABAN/CNAB
            Result.Append("".FillLeft(28));                                 //Uso exclusivo FEBRABAN/CNAB

			return Result.ToString().ToUpper();
		}

        /// <summary>
        /// Gerars the registro trailler400.
        /// </summary>
        /// <param name="ARemessa">A remessa.</param>
        public override void GerarRegistroTrailler400(List<string> ARemessa)
        {
			var wLinha = new StringBuilder();
			wLinha.Append('9');
			wLinha.Append("".FillLeft(393));                         // TIPO DE REGISTRO
            wLinha.AppendFormat("{0:000000}", ARemessa.Count + 1);   // N�MERO SEQ�ENCIAL DO REGISTRO NO ARQUIVO
			ARemessa.Add(wLinha.ToString().ToUpper());
        }

        /// <summary>
        /// Gerars the registro trailler240.
        /// </summary>
        /// <param name="ARemessa">A remessa.</param>
        /// <returns>System.String.</returns>
        public override string GerarRegistroTrailler240(List<string> ARemessa)
        {
			var Result = new StringBuilder();
            //REGISTRO TRAILER DO LOTE
			Result.AppendFormat("{0:000}", Banco.Numero);        //C�digo do banco
            Result.Append("0001");                               //N�mero do lote
            Result.Append("5");                                  //Tipo do registro: Registro trailer do lote
            Result.Append("".FillLeft(9));                       //Uso exclusivo FEBRABAN/CNAB
            Result.AppendFormat("{0:000000}", ARemessa.Count);   //Quantidade de Registro da Remessa
            Result.Append("".ZeroFill(6));                       //Quantidade de t�tulos em cobran�a simples
            Result.Append("".ZeroFill(17));                      //Valor dos t�tulos em cobran�a simples
            Result.Append("".ZeroFill(6));                       //Quantidade t�tulos em cobran�a vinculada
            Result.Append("".ZeroFill(17));                      //Valor dos t�tulos em cobran�a vinculada
            Result.Append("".ZeroFill(46));                      //Complemento
            Result.Append("".FillLeft(8));                       //Referencia do aviso bancario
            Result.Append("".FillLeft(117));

          //GERAR REGISTRO TRAILER DO ARQUIVO
    		Result.Append(Environment.NewLine);
            Result.AppendFormat("{0:000}", Banco.Numero);        //C�digo do banco
            Result.Append("9999");                               //Lote de servi�o
			Result.Append("9");                                  //Tipo do registro: Registro trailer do arquivo
            Result.Append("".FillLeft(9));                       //Uso exclusivo FEBRABAN/CNAB}
            Result.Append("000001");                             //Quantidade de lotes do arquivo}
            Result.AppendFormat("{0:000000}", ARemessa.Count);   //Quantidade de registros do arquivo, inclusive este registro que est� sendo criado agora}
            Result.Append("".ZeroFill(6));                       //Complemento
            Result.Append("".FillLeft(205));

			return Result.ToString().ToUpper();
        }

        /// <summary>
        /// Lers the retorno400.
        /// </summary>
        /// <param name="ARetorno">A retorno.</param>
        /// <exception cref="System.NotImplementedException">Esta fun��o n�o esta implementada para este banco</exception>
        public override void LerRetorno400(List<string> ARetorno)
        {
			if (ARetorno[0].ExtrairInt32DaPosicao(77, 79) != Numero)
				throw new ACBrException(string.Format("{0} n�o � um arquivo de retorno do {1}",
													   Banco.Parent.NomeArqRetorno, Nome));

			var rCedente = ARetorno[0].ExtrairDaPosicao(47, 76);
			var rAgencia = ARetorno[0].ExtrairDaPosicao(27, 30).Trim();
			var rDigitoAgencia = ARetorno[0].ExtrairDaPosicao(31, 31);
			var rConta = ARetorno[0].ExtrairDaPosicao(32, 39).Trim();
			var rDigitoConta = ARetorno[0].ExtrairDaPosicao(40, 40).Trim();			

			if (!Banco.Parent.LeCedenteRetorno && (rAgencia != Banco.Parent.Cedente.Agencia.OnlyNumbers() ||
				rConta != Banco.Parent.Cedente.Conta.OnlyNumbers()))
				throw new ACBrException(@"Agencia\Conta do arquivo inv�lido");

			Banco.Parent.NumeroArquivo = ARetorno[0].ExtrairInt32DaPosicao(109, 113);
			Banco.Parent.DataArquivo = ARetorno[0].ExtrairDataDaPosicao(95, 100);
			Banco.Parent.DataCreditoLanc = ARetorno[0].ExtrairDataDaPosicao(114, 119);

			Banco.Parent.Cedente.TipoInscricao = (PessoaCedente)ARetorno[1].ExtrairInt32DaPosicao(2, 3);

			switch (Banco.Parent.Cedente.TipoInscricao)
			{
				case PessoaCedente.Fisica:
					Banco.Parent.Cedente.CNPJCPF = ARetorno[1].ExtrairDaPosicao(7, 17);
					break;

				case PessoaCedente.Juridica:
					Banco.Parent.Cedente.CNPJCPF = ARetorno[1].ExtrairDaPosicao(4, 17);
					break;
			}

			Banco.Parent.Cedente.Nome = rCedente;
			Banco.Parent.Cedente.Agencia = rAgencia;
			Banco.Parent.Cedente.AgenciaDigito = rDigitoAgencia;
			Banco.Parent.Cedente.Conta = rConta;
			Banco.Parent.Cedente.ContaDigito = rDigitoConta;

			Banco.Parent.ListadeBoletos.Clear();
						
			Titulo Titulo;
			for (int ContLinha = 1; ContLinha < ARetorno.Count - 1; ContLinha++)
			{
				var Linha = ARetorno[ContLinha];

				if (Linha.ExtrairDaPosicao(1, 1) != "7" && Linha.ExtrairDaPosicao(1, 1) != "1")
					continue;

				Titulo = Banco.Parent.CriarTituloNaLista();

				Titulo.SeuNumero = Linha.ExtrairDaPosicao(38, 62);
				Titulo.NumeroDocumento = Linha.ExtrairDaPosicao(117, 126);
				Titulo.OcorrenciaOriginal.Tipo = CodOcorrenciaToTipo(Linha.ExtrairInt32DaPosicao(109, 110));

				if (Titulo.OcorrenciaOriginal.Tipo.IsIn(TipoOcorrencia.RetornoInstrucaoProtestoRejeitadaSustadaOuPendente,
					TipoOcorrencia.RetornoAlegacaoDoSacado, TipoOcorrencia.RetornoInstrucaoCancelada))
				{
					var MotivoLinha = 302;
					var motivo = Linha.ExtrairDaPosicao(MotivoLinha, MotivoLinha + 3).Trim();
					Titulo.MotivoRejeicaoComando.Add(string.IsNullOrEmpty(motivo) ? "0000" : motivo);
					
					if(Titulo.MotivoRejeicaoComando[0] != "0000")
					{
						var CodOcorrencia = Titulo.MotivoRejeicaoComando[0].ToInt32();
						var mdescricao = CodMotivoRejeicaoToDescricao(Titulo.OcorrenciaOriginal.Tipo, CodOcorrencia);
						Titulo.DescricaoMotivoRejeicaoComando.Add(mdescricao);
					}
				}
				else
				{					
					int MotivoLinha = 378;
					int CodMotivo;
					for (int i = 0; i < 3; i++)
					{						
						Titulo.MotivoRejeicaoComando.Add(Linha.ExtrairDaPosicao(MotivoLinha, MotivoLinha + 1));
						if (Titulo.MotivoRejeicaoComando[i] != "00")
						{
							CodMotivo = Titulo.MotivoRejeicaoComando[i].ToInt32();
							Titulo.DescricaoMotivoRejeicaoComando.Add(CodMotivoRejeicaoToDescricao(Titulo.OcorrenciaOriginal.Tipo, CodMotivo));
						}
						MotivoLinha += 2;
					}
				}

				Titulo.DataOcorrencia = Linha.ExtrairDataDaPosicao(111, 116);

				//Esp�cie do documento
				switch (Linha.ExtrairDaPosicao(174, 175).Trim().ToInt32())
				{
					case 1: Titulo.EspecieDoc = "DM"; break;
					case 2: Titulo.EspecieDoc = "NP"; break;
					case 3: Titulo.EspecieDoc = "NS"; break;
					case 4: Titulo.EspecieDoc = "ME"; break;
					case 5: Titulo.EspecieDoc = "RC"; break;
					case 6: Titulo.EspecieDoc = "CT"; break;
					case 7: Titulo.EspecieDoc = "CS"; break;
					case 8: Titulo.EspecieDoc = "DS"; break;
					case 9: Titulo.EspecieDoc = "LC"; break;
					case 13: Titulo.EspecieDoc = "ND"; break;
					case 15: Titulo.EspecieDoc = "DD"; break;
					case 16: Titulo.EspecieDoc = "EC"; break;
					case 17: Titulo.EspecieDoc = "PS"; break;
					default: Titulo.EspecieDoc = "DV"; break;
				}

				Titulo.Vencimento = Linha.ExtrairDataDaPosicao(147, 152);

				Titulo.ValorDocumento = Linha.ExtrairDecimalDaPosicao(153, 165);
				Titulo.ValorIOF = Linha.ExtrairDecimalDaPosicao(215, 227);
				Titulo.ValorAbatimento = Linha.ExtrairDecimalDaPosicao(228, 240);
				Titulo.ValorDesconto = Linha.ExtrairDecimalDaPosicao(241, 253);
				Titulo.ValorRecebido = Linha.ExtrairDecimalDaPosicao(254, 266);
				Titulo.ValorMoraJuros = Linha.ExtrairDecimalDaPosicao(267, 279);
				Titulo.ValorOutrosCreditos = Linha.ExtrairDecimalDaPosicao(280, 292);
				Titulo.NossoNumero = Linha.ExtrairDaPosicao(64, 80);
				Titulo.Carteira = Linha.ExtrairDaPosicao(92, 94);
				Titulo.ValorDespesaCobranca = Linha.ExtrairDecimalDaPosicao(176, 188);

				Titulo.NossoNumero = Linha.ExtrairDaPosicao(63, 70);
				Titulo.Carteira = Linha.ExtrairDaPosicao(83, 85);

				var tempdata = Linha.ExtrairDataOpcionalDaPosicao(296, 301);
				if (tempdata.HasValue)
					Titulo.DataCredito = tempdata.Value;

				tempdata = Linha.ExtrairDataOpcionalDaPosicao(111, 116);
				if (tempdata.HasValue)
					Titulo.DataBaixa = tempdata.Value;
			}
        }

        /// <summary>
        /// Lers the retorno240.
        /// </summary>
        /// <param name="ARetorno">A retorno.</param>
        /// <exception cref="System.NotImplementedException">Esta fun��o n�o esta implementada para este banco</exception>
        public override void LerRetorno240(List<string> ARetorno)
        {
			if (ARetorno[0].ExtrairInt32DaPosicao(1, 3) != Numero)
				throw new ACBrException(string.Format("{0} n�o � um arquivo de retorno do {1}'",
					Banco.Parent.NomeArqRetorno, Nome));

			Banco.Parent.DataArquivo = ARetorno[0].ExtrairDataDaPosicao(146, 152);
			Banco.Parent.NumeroArquivo = ARetorno[0].ExtrairInt32DaPosicao(158, 163);

			var rCedente = ARetorno[0].ExtrairDaPosicao(73, 102).Trim();
			var rCNPJCPF = ARetorno[0].ExtrairDaPosicao(19, 32).OnlyNumbers();

			if (!Banco.Parent.LeCedenteRetorno && rCNPJCPF != Banco.Parent.Cedente.CNPJCPF.OnlyNumbers())
				throw new ACBrException(@"CNPJ\CPF do arquivo inv�lido");

			Banco.Parent.Cedente.Nome = rCedente;
			Banco.Parent.Cedente.CNPJCPF = rCNPJCPF;

			switch (ARetorno[0].ExtrairInt32DaPosicao(18, 18))
			{
				case 1:
					Banco.Parent.Cedente.TipoInscricao = PessoaCedente.Fisica;
					break;

				default:
					Banco.Parent.Cedente.TipoInscricao = PessoaCedente.Juridica;
					break;
			}

			Banco.Parent.ListadeBoletos.Clear();

			Titulo titulo = null;

			for (int ContLinha = 1; ContLinha < ARetorno.Count - 1; ContLinha++)
			{
				var Linha = ARetorno[ContLinha];

				// verifica se o registro (linha) � um registro detalhe (segmento J)
				if (Linha.ExtrairInt32DaPosicao(8, 8) != 3)
					continue;

				// se for segmento T cria um novo titulo                
				if (Linha.ExtrairDaPosicao(14, 14) == "T")
				{
					titulo = Banco.Parent.CriarTituloNaLista();

					titulo.SeuNumero = Linha.ExtrairDaPosicao(59, 68);
					titulo.NumeroDocumento = Linha.ExtrairDaPosicao(59, 68);
					titulo.Carteira = Linha.ExtrairDaPosicao(38, 40);

					var dt = Linha.ExtrairDataOpcionalDaPosicao(74, 81);
					if (dt.HasValue)
						titulo.Vencimento = dt.Value;

					titulo.ValorDocumento = Linha.ExtrairDecimalDaPosicao(82, 96);
					titulo.NossoNumero = Linha.ExtrairDaPosicao(41, 48);
					titulo.ValorDespesaCobranca = Linha.ExtrairDecimalDaPosicao(199, 213);
					titulo.OcorrenciaOriginal.Tipo = CodOcorrenciaToTipo(Linha.ExtrairInt32DaPosicao(16, 17));

					var IdxMotivo = 214;
					while (IdxMotivo < 221)
					{
						if (!string.IsNullOrEmpty(Linha.ExtrairDaPosicao(IdxMotivo, IdxMotivo + 1)) || 
							!Linha.ExtrairDaPosicao(IdxMotivo, IdxMotivo + 1).Equals("00"))
						{
							titulo.MotivoRejeicaoComando.Add(Linha.ExtrairDaPosicao(IdxMotivo, IdxMotivo + 1));
							titulo.DescricaoMotivoRejeicaoComando.Add(
								CodMotivoRejeicaoToDescricao(titulo.OcorrenciaOriginal.Tipo,
								Linha.ExtrairInt32DaPosicao(IdxMotivo, IdxMotivo + 1)));
						}
						IdxMotivo += 2;
					}
				}
				else
				{
					// segmento U
					titulo.ValorIOF = Linha.ExtrairDecimalDaPosicao(63, 77);
					titulo.ValorAbatimento = Linha.ExtrairDecimalDaPosicao(48, 62);
					titulo.ValorDesconto = Linha.ExtrairDecimalDaPosicao(33, 47);
					titulo.ValorMoraJuros = Linha.ExtrairDecimalDaPosicao(18, 32);
					titulo.ValorOutrosCreditos = Linha.ExtrairDecimalDaPosicao(123, 137);
					titulo.ValorRecebido = Linha.ExtrairDecimalDaPosicao(78, 92);
					titulo.ValorOutrasDespesas = Linha.ExtrairDecimalDaPosicao(108, 113);

					var TempData = Linha.ExtrairDataOpcionalDaPosicao(138, 145);
					if (TempData.HasValue)
						titulo.DataOcorrencia = TempData.Value;

					TempData = Linha.ExtrairDataOpcionalDaPosicao(146, 153);
					if (TempData.HasValue)
						titulo.DataCredito = TempData.Value;
				}
			}
        }

        #endregion Methods
    }
}