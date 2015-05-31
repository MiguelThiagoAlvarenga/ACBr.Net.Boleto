// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 04-21-2014
//
// Last Modified By : RFTD
// Last Modified On : 04-28-2014
// ***********************************************************************
// <copyright file="Bradesco.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Text;
using ACBr.Net.Boleto.Enums;
using ACBr.Net.Boleto.Utils;
using ACBr.Net.Core.Enum;
using ACBr.Net.Core.Exceptions;
using ACBr.Net.Core.Extensions;

#region COM Interop Attributes

#if COM_INTEROP
using System.Runtime.InteropServices;
#endif


#endregion COM Interop Attributes

namespace ACBr.Net.Boleto.Bancos
{
    #region COM Interop Attributes

#if COM_INTEROP

	[ComVisible(true)]
	[Guid("7AD8EC33-F986-438D-A5CB-F32D3DDD8821")]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

    #endregion COM Interop Attributes
    /// <summary>
    /// Classe Bradesco. This class cannot be inherited.
    /// </summary>
    public sealed class BancoBradesco : BancoBase
    {
        #region Fields
        #endregion Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="BancoBase" /> class.
        /// </summary>
        /// <param name="parent">The parent.</param>
        internal BancoBradesco(Banco parent)
            : base(parent)
        {
            TipoCobranca = TipoCobranca.Bradesco;
            Nome = "Bradesco";
            Digito = 2;
            Numero = 237;
            TamanhoMaximoNossoNum = 11;
            TamanhoAgencia = 4;
            TamanhoConta = 7;
            TamanhoCarteira = 2;    
        }

        #endregion Constructor

        #region Propriedades
        #endregion Propriedades

        #region Methods

        /// <summary>
        /// Tipoes the ocorrencia to descricao.
        /// </summary>
        /// <param name="tipo">The tipo.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException">Esta fun��o n�o esta implementada para este banco</exception>
        public override string TipoOcorrenciaToDescricao(TipoOcorrencia tipo)
        {
            switch ((int)tipo)
            {
                case 2:
                    return "02-Entrada Confirmada";

                case 3:
                    return "03-Entrada Rejeitada";

                case 6:
                    return "06-Liquida��o normal";

                case 9:
                    return "09-Baixado Automaticamente via Arquivo";

                case 10: 
                    return "10-Baixado conforme instru��es da Ag�ncia";

                case 11: 
                    return "11-Em Ser - Arquivo de T�tulos pendentes";

                case 12: 
                    return "12-Abatimento Concedido";

                case 13:
                    return "13-Abatimento Cancelado";

                case 14: return "14-Vencimento Alterado";

                case 15: 
                    return "15-Liquida��o em Cart�rio";

                case 16: 
                    return "16-Titulo Pago em Cheque - Vinculado";

                case 17:
                    return "17-Liquida��o ap�s baixa ou T�tulo n�o registrado";

                case 18:
                    return "18-Acerto de Deposit�ria";

                case 19:
                    return "19-Confirma��o Recebimento Instru��o de Protesto";

                case 20:
                    return "20-Confirma��o Recebimento Instru��o Susta��o de Protesto";

                case 21:
                    return "21-Acerto do Controle do Participante";

                case 22:
                    return "22-Titulo com Pagamento Cancelado";

                case 23:
                    return "23-Entrada do T�tulo em Cart�rio";

                case 24:
                    return "24-Entrada rejeitada por CEP Irregular";

                case 27:
                    return "27-Baixa Rejeitada";

                case 28: return "28-D�bito de tarifas/custas";

                case 29:
                    return "29-Ocorr�ncias do Sacado";

                case 30:
                    return "30-Altera��o de Outros Dados Rejeitados";

                case 32:
                    return "32-Instru��o Rejeitada";

                case 33:
                    return "33-Confirma��o Pedido Altera��o Outros Dados";

                case 34:
                    return "34-Retirado de Cart�rio e Manuten��o Carteira";

                case 35:
                    return "35-Desagendamento do d�bito autom�tico";

                case 40:
                    return "40-Estorno de Pagamento";

                case 55:
                    return "55-Sustado Judicial";

                case 68:
                    return "68-Acerto dos dados do rateio de Cr�dito";

                case 69:
                    return "69-Cancelamento dos dados do rateio";

                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Cods the ocorrencia to tipo.
        /// </summary>
        /// <param name="codOcorrencia">The cod ocorrencia.</param>
        /// <returns>TipoOcorrencia.</returns>
        /// <exception cref="System.NotImplementedException">Esta fun��o n�o esta implementada para este banco</exception>
        public override TipoOcorrencia CodOcorrenciaToTipo(int codOcorrencia)
        {
            switch (codOcorrencia)
            {
                case 2: return TipoOcorrencia.RetornoRegistroConfirmado;
                case 3: return TipoOcorrencia.RetornoRegistroRecusado;
                case 6: return TipoOcorrencia.RetornoLiquidado;
                case 9: return TipoOcorrencia.RetornoBaixadoViaArquivo;
                case 10: return TipoOcorrencia.RetornoBaixadoInstAgencia;
                case 11: return TipoOcorrencia.RetornoTituloEmSer;
                case 12: return TipoOcorrencia.RetornoAbatimentoConcedido;
                case 13: return TipoOcorrencia.RetornoAbatimentoCancelado;
                case 14: return TipoOcorrencia.RetornoVencimentoAlterado;
                case 15: return TipoOcorrencia.RetornoLiquidadoEmCartorio;
                case 16: return TipoOcorrencia.RetornoTituloPagoEmCheque;
                case 17: return TipoOcorrencia.RetornoLiquidadoAposBaixaOuNaoRegistro;
                case 18: return TipoOcorrencia.RetornoAcertoDepositaria;
                case 19: return TipoOcorrencia.RetornoRecebimentoInstrucaoProtestar;
                case 20: return TipoOcorrencia.RetornoRecebimentoInstrucaoSustarProtesto;
                case 21: return TipoOcorrencia.RetornoAcertoControleParticipante;
                case 22: return TipoOcorrencia.RetornoTituloPagamentoCancelado;
                case 23: return TipoOcorrencia.RetornoEncaminhadoACartorio;
                case 24: return TipoOcorrencia.RetornoEntradaRejeitaCEPIrregular;
                case 27: return TipoOcorrencia.RetornoBaixaRejeitada;
                case 28: return TipoOcorrencia.RetornoDebitoTarifas;
                case 29: return TipoOcorrencia.RetornoOcorrenciasDoSacado;
                case 30: return TipoOcorrencia.RetornoAlteracaoOutrosDadosRejeitada;
                case 32: return TipoOcorrencia.RetornoComandoRecusado;
                case 33: return TipoOcorrencia.RetornoRecebimentoInstrucaoAlterarDados;
                case 34: return TipoOcorrencia.RetornoRetiradoDeCartorio;
                case 35: return TipoOcorrencia.RetornoDesagendamentoDebitoAutomatico;
                case 99: return TipoOcorrencia.RetornoRegistroRecusado;
                default: return TipoOcorrencia.RetornoOutrasOcorrencias;
            }
        }

        /// <summary>
        /// Tipoes the o correncia to cod.
        /// </summary>
        /// <param name="tipo">The tipo.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException">Esta fun��o n�o esta implementada para este banco</exception>
        public override string TipoOCorrenciaToCod(TipoOcorrencia tipo)
        {
            switch (tipo)
            {
                case TipoOcorrencia.RetornoRegistroConfirmado: return "02";
                case TipoOcorrencia.RetornoRegistroRecusado: return "03";
                case TipoOcorrencia.RetornoLiquidado: return "06";
                case TipoOcorrencia.RetornoBaixadoViaArquivo: return "09";
                case TipoOcorrencia.RetornoBaixadoInstAgencia: return "10";
                case TipoOcorrencia.RetornoTituloEmSer: return "11";
                case TipoOcorrencia.RetornoAbatimentoConcedido: return "12";
                case TipoOcorrencia.RetornoAbatimentoCancelado: return "13";
                case TipoOcorrencia.RetornoVencimentoAlterado: return "14";
                case TipoOcorrencia.RetornoLiquidadoEmCartorio: return "15";
                case TipoOcorrencia.RetornoTituloPagoEmCheque: return "16";
                case TipoOcorrencia.RetornoLiquidadoAposBaixaOuNaoRegistro: return "17";
                case TipoOcorrencia.RetornoAcertoDepositaria: return "18";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoProtestar: return "19";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoSustarProtesto: return "20";
                case TipoOcorrencia.RetornoAcertoControleParticipante: return "21";
                case TipoOcorrencia.RetornoTituloPagamentoCancelado: return "22";
                case TipoOcorrencia.RetornoEncaminhadoACartorio: return "23";
                case TipoOcorrencia.RetornoEntradaRejeitaCEPIrregular: return "24";
                case TipoOcorrencia.RetornoBaixaRejeitada: return "27";
                case TipoOcorrencia.RetornoDebitoTarifas: return "28";
                case TipoOcorrencia.RetornoOcorrenciasDoSacado: return "29";
                case TipoOcorrencia.RetornoAlteracaoOutrosDadosRejeitada: return "30";
                case TipoOcorrencia.RetornoComandoRecusado: return "32";
                case TipoOcorrencia.RetornoRecebimentoInstrucaoAlterarDados: return "33";
                case TipoOcorrencia.RetornoRetiradoDeCartorio: return "34";
                case TipoOcorrencia.RetornoDesagendamentoDebitoAutomatico: return "35";
                default: return "02";
            }
        }

        /// <summary>
        /// Cods the motivo rejeicao to descricao.
        /// </summary>
        /// <param name="tipo">The tipo.</param>
        /// <param name="codMotivo">The cod motivo.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException">Esta fun��o n�o esta implementada para este banco</exception>
        public override string CodMotivoRejeicaoToDescricao(TipoOcorrencia tipo, int codMotivo)
        {
            switch (tipo)
            {
                case TipoOcorrencia.RetornoRegistroConfirmado:
                    switch (codMotivo)
                    {
                        case 0: return "00-Ocorrencia aceita";
                        case 1: return "01-Codigo de banco inv�lido";
                        case 4: return "04-Cod. movimentacao nao permitido p/ a carteira";
                        case 15: return "15-Caracteristicas de Cobranca Imcompativeis";
                        case 17: return "17-Data de vencimento anterior a data de emiss�o";
                        case 21: return "21-Esp�cie do T�tulo inv�lido";
                        case 24: return "24-Data da emiss�o inv�lida";
                        case 38: return "38-Prazo para protesto inv�lido";
                        case 39: return "39-Pedido para protesto n�o permitido para t�tulo";
                        case 43: return "43-Prazo para baixa e devolu��o inv�lido";
                        case 45: return "45-Nome do Sacado inv�lido";
                        case 46: return "46-Tipo/num. de inscri��o do Sacado inv�lidos";
                        case 47: return "47-Endere�o do Sacado n�o informado";
                        case 48: return "48-CEP invalido";
                        case 50: return "50-CEP referente a Banco correspondente";
                        case 53: return "53-N� de inscri��o do Sacador/avalista inv�lidos (CPF/CNPJ)";
                        case 54: return "54-Sacador/avalista n�o informado";
                        case 67: return "67-D�bito autom�tico agendado";
                        case 68: return "68-D�bito n�o agendado - erro nos dados de remessa";
                        case 69: return "69-D�bito n�o agendado - Sacado n�o consta no cadastro de autorizante";
                        case 70: return "70-D�bito n�o agendado - Cedente n�o autorizado pelo Sacado";
                        case 71: return "71-D�bito n�o agendado - Cedente n�o participa da modalidade de d�bito autom�tico";
                        case 72: return "72-D�bito n�o agendado - C�digo de moeda diferente de R$";
                        case 73: return "73-D�bito n�o agendado - Data de vencimento inv�lida";
                        case 75: return "75-D�bito n�o agendado - Tipo do n�mero de inscri��o do sacado debitado inv�lido";
                        case 86: return "86-Seu n�mero do documento inv�lido";
                        case 89: return "89-Email sacado nao enviado - Titulo com debito automatico";
                        case 90: return "90-Email sacado nao enviado - Titulo com cobranca sem registro";
                        default: return string.Format("{0:00} - Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoRegistroRecusado:
                    switch (codMotivo)
                    {
                        case 2: return "02-Codigo do registro detalhe invalido";
                        case 3: return "03-Codigo da Ocorrencia Invalida";
                        case 4: return "04-Codigo da Ocorrencia nao permitida para a carteira";
                        case 5: return "05-Codigo de Ocorrencia nao numerico";
                        case 7: return "Agencia\\Conta\\Digito invalido";
                        case 8: return "Nosso numero invalido";
                        case 09: return "Nosso numero duplicado";
                        case 10: return "Carteira invalida";
                        case 13: return "Idetificacao da emissao do boleto invalida";
                        case 16: return "Data de vencimento invalida";
                        case 18: return "Vencimento fora do prazo de operacao";
                        case 20: return "Valor do titulo invalido";
                        case 21: return "Especie do titulo invalida";
                        case 22: return "Especie nao permitida para a carteira";
                        case 24: return "Data de emissao invalida";
                        case 28: return "Codigo de desconto invalido";
                        case 38: return "Prazo para protesto invalido";
                        case 44: return "Agencia cedente nao prevista";
                        case 45: return "Nome cedente nao informado";
                        case 46: return "Tipo/numero inscricao sacado invalido";
                        case 47: return "Endereco sacado nao informado";
                        case 48: return "CEP invalido";
                        case 50: return "CEP irregular - Banco correspondente";
                        case 63: return "Entrada para titulo ja cadastrado";
                        case 65: return "Limite excedido";
                        case 66: return "Numero autorizacao inexistente";
                        case 68: return "Debito nao agendado - Erro nos dados da remessa";
                        case 69: return "Debito nao agendado - Sacado nao consta no cadastro de autorizante";
                        case 70: return "Debito nao agendado - Cedente nao autorizado pelo sacado";
                        case 71: return "Debito nao agendado - Cedente nao participa de debito automatico";
                        case 72: return "Debito nao agendado - Codigo de moeda diferente de R$";
                        case 73: return "Debito nao agendado - Data de vencimento invalida";
                        case 74: return "Debito nao agendado - Conforme seu pedido titulo nao registrado";
                        case 75: return "Debito nao agendado - Tipo de numero de inscricao de debitado invalido";
                        default: return string.Format("{0:00} - Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoLiquidado:
                    switch (codMotivo)
                    {
                        case 0: return "00-Titulo pago com dinheiro";
                        case 15: return "15-Titulo pago com cheque";
                        case 42: return "42-Rateio nao efetuado";  
                        default: return string.Format("{0:00} - Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoBaixadoViaArquivo:
                    switch (codMotivo)
                    {
                            case 0: return "00-Ocorrencia aceita";
                            case 10: return "10-Baixa comandada pelo cliente";
                        default: return string.Format("{0:00} - Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoBaixadoInstAgencia:
                    switch (codMotivo)
                    {
                        case 0: return "00-Baixado conforme instrucoes na agencia";
                        case 14: return "14-Titulo protestado";
                        case 15: return "15-Titulo excluido";
                        case 16: return "16-Titulo baixado pelo banco por decurso de prazo";
                        case 20: return "20-Titulo baixado e transferido para desconto";  
                        default: return string.Format("{0:00} - Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoLiquidadoAposBaixaOuNaoRegistro:
                    switch (codMotivo)
                    {
                        case 0: return "00-Pago com dinheiro";
                        case 15: return "15-Pago com cheque";  
                        default: return string.Format("{0:00} - Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoLiquidadoEmCartorio:
                    switch (codMotivo)
                    {
                        case 0: return "00-Pago com dinheiro";
                        case 15: return "15-Pago com cheque";  
                        default: return string.Format("{0:00} - Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoEntradaRejeitaCEPIrregular:
                    switch (codMotivo)
                    {
                        case 48: return "48-CEP invalido";
                        default: return string.Format("{0:00} - Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoBaixaRejeitada:
                    switch (codMotivo)
                    {
                        case 4: return "04-Codigo de ocorrencia nao permitido para a carteira";
                        case 7: return "07-Agencia\\Conta\\Digito invalidos";
                        case 8: return "08-Nosso numero invalido";
                        case 10: return "10-Carteira invalida";
                        case 15: return "15-Carteira\\Agencia\\Conta\\NossoNumero invalidos";
                        case 40: return "40-Titulo com ordem de protesto emitido";
                        case 42: return "42-Codigo para baixa/devolucao via Telebradesco invalido";
                        case 60: return "60-Movimento para titulo nao cadastrado";
                        case 77: return "70-Transferencia para desconto nao permitido para a carteira";
                        case 85: return "85-Titulo com pagamento vinculado";
                        default: return string.Format("{0:00} - Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoDebitoTarifas:
                    switch (codMotivo)
                    {
                        case 2: return "02-Tarifa de perman�ncia t�tulo cadastrado";
                        case 3: return "03-Tarifa de susta��o";
                        case 4: return "04-Tarifa de protesto";
                        case 5: return "05-Tarifa de outras instrucoes";
                        case 6: return "06-Tarifa de outras ocorr�ncias";
                        case 8: return "08-Custas de protesto";
                        case 12: return "12-Tarifa de registro";
                        case 13: return "13-Tarifa titulo pago no Bradesco";
                        case 14: return "14-Tarifa titulo pago compensacao";
                        case 15: return "15-Tarifa t�tulo baixado n�o pago";
                        case 16: return "16-Tarifa alteracao de vencimento";
                        case 17: return "17-Tarifa concess�o abatimento";
                        case 18: return "18-Tarifa cancelamento de abatimento";
                        case 19: return "19-Tarifa concess�o desconto";
                        case 20: return "20-Tarifa cancelamento desconto";
                        case 21: return "21-Tarifa t�tulo pago cics";
                        case 22: return "22-Tarifa t�tulo pago Internet";
                        case 23: return "23-Tarifa t�tulo pago term. gerencial servi�os";
                        case 24: return "24-Tarifa t�tulo pago P�g-Contas";
                        case 25: return "25-Tarifa t�tulo pago Fone F�cil";
                        case 26: return "26-Tarifa t�tulo D�b. Postagem";
                        case 27: return "27-Tarifa impress�o de t�tulos pendentes";
                        case 28: return "28-Tarifa t�tulo pago BDN";
                        case 29: return "29-Tarifa t�tulo pago Term. Multi Funcao";
                        case 30: return "30-Impress�o de t�tulos baixados";
                        case 31: return "31-Impress�o de t�tulos pagos";
                        case 32: return "32-Tarifa t�tulo pago Pagfor";
                        case 33: return "33-Tarifa reg/pgto � guich� caixa";
                        case 34: return "34-Tarifa t�tulo pago retaguarda";
                        case 35: return "35-Tarifa t�tulo pago Subcentro";
                        case 36: return "36-Tarifa t�tulo pago Cartao de Credito";
                        case 37: return "37-Tarifa t�tulo pago Comp Eletr�nica";
                        case 38: return "38-Tarifa t�tulo Baix. Pg. Cartorio";
                        case 39: return "39-Tarifa t�tulo baixado acerto BCO";
                        case 40: return "40-Baixa registro em duplicidade";
                        case 41: return "41-Tarifa t�tulo baixado decurso prazo";
                        case 42: return "42-Tarifa t�tulo baixado Judicialmente";
                        case 43: return "43-Tarifa t�tulo baixado via remessa";
                        case 44: return "44-Tarifa t�tulo baixado rastreamento";
                        case 45: return "45-Tarifa t�tulo baixado conf. Pedido";
                        case 46: return "46-Tarifa t�tulo baixado protestado";
                        case 47: return "47-Tarifa t�tulo baixado p/ devolucao";
                        case 48: return "48-Tarifa t�tulo baixado franco pagto";
                        case 49: return "49-Tarifa t�tulo baixado SUST/RET/CART�RIO";
                        case 50: return "50-Tarifa t�tulo baixado SUS/SEM/REM/CART�RIO";
                        case 51: return "51-Tarifa t�tulo transferido desconto";
                        case 52: return "52-Cobrado baixa manual";
                        case 53: return "53-Baixa por acerto cliente";
                        case 54: return "54-Tarifa baixa por contabilidade";
                        case 55: return "55-BIFAX";
                        case 56: return "56-Consulta informa��es via internet";
                        case 57: return "57-Arquivo retorno via internet";
                        case 58: return "58-Tarifa emiss�o Papeleta";
                        case 59: return "59-Tarifa fornec papeleta semi preenchida";
                        case 60: return "60-Acondicionador de papeletas (RPB)S";
                        case 61: return "61-Acond. De papelatas (RPB)s PERSONAL";
                        case 62: return "62-Papeleta formul�rio branco";
                        case 63: return "63-Formul�rio A4 serrilhado";
                        case 64: return "64-Fornecimento de softwares transmiss";
                        case 65: return "65-Fornecimento de softwares consulta";
                        case 66: return "66-Fornecimento Micro Completo";
                        case 67: return "67-Fornecimento MODEN";
                        case 68: return "68-Fornecimento de m�quina FAX";
                        case 69: return "69-Fornecimento de maquinas oticas";
                        case 70: return "70-Fornecimento de Impressoras";
                        case 71: return "71-Reativa��o de t�tulo";
                        case 72: return "72-Altera��o de produto negociado";
                        case 73: return "73-Tarifa emissao de contra recibo";
                        case 74: return "74-Tarifa emissao 2� via papeleta";
                        case 75: return "75-Tarifa regrava��o arquivo retorno";
                        case 76: return "76-Arq. T�tulos a vencer mensal";
                        case 77: return "77-Listagem auxiliar de cr�dito";
                        case 78: return "78-Tarifa cadastro cartela instru��o permanente";
                        case 79: return "79-Canaliza��o de Cr�dito";
                        case 80: return "80-Cadastro de Mensagem Fixa";
                        case 81: return "81-Tarifa reapresenta��o autom�tica t�tulo";
                        case 82: return "82-Tarifa registro t�tulo d�b. Autom�tico";
                        case 83: return "83-Tarifa Rateio de Cr�dito";
                        case 84: return "84-Emiss�o papeleta sem valor";
                        case 85: return "85-Sem uso";
                        case 86: return "86-Cadastro de reembolso de diferen�a";
                        case 87: return "87-Relat�rio fluxo de pagto";
                        case 88: return "88-Emiss�o Extrato mov. Carteira";
                        case 89: return "89-Mensagem campo local de pagto";
                        case 90: return "90-Cadastro Concession�ria serv. Publ.";
                        case 91: return "91-Classif. Extrato Conta Corrente";
                        case 92: return "92-Contabilidade especial";
                        case 93: return "93-Realimenta��o pagto";
                        case 94: return "94-Repasse de Cr�ditos";
                        case 95: return "95-Tarifa reg. pagto Banco Postal";
                        case 96: return "96-Tarifa reg. Pagto outras m�dias";
                        case 97: return "97-Tarifa Reg/Pagto � Net Empresa";
                        case 98: return "98-Tarifa t�tulo pago vencido";
                        case 99: return "99-TR T�t. Baixado por decurso prazo";
                        case 100: return "100-Arquivo Retorno Antecipado";
                        case 101: return "101-Arq retorno Hora/Hora";
                        case 102: return "102-TR. Agendamento D�b Aut";
                        case 103: return "103-TR. Tentativa cons D�b Aut";
                        case 104: return "104-TR Cr�dito on-line";
                        case 105: return "105-TR. Agendamento rat. Cr�dito";
                        case 106: return "106-TR Emiss�o aviso rateio";
                        case 107: return "107-Extrato de protesto";
                        case 110: return "110-Tarifa reg/pagto Bradesco Expresso";
                        default: return string.Format("{0:00} - Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoOcorrenciasDoSacado:
                    switch (codMotivo)
                    {
                        case 78: return "78-Sacado alega que faturamento e indevido";
                        case 116: return "116-Sacado aceita/reconhece o faturamento";
                        default: return string.Format("{0:00} - Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoAlteracaoOutrosDadosRejeitada:
                    switch (codMotivo)
                    {
                        case 1: return "01-C�digo do Banco inv�lido";
                        case 4: return "04-C�digo de ocorr�ncia n�o permitido para a carteira";
                        case 5: return "05-C�digo da ocorr�ncia n�o num�rico";
                        case 8: return "08-Nosso n�mero inv�lido";
                        case 15: return "15-Caracter�stica da cobran�a incompat�vel";
                        case 16: return "16-Data de vencimento inv�lido";
                        case 17: return "17-Data de vencimento anterior a data de emiss�o";
                        case 18: return "18-Vencimento fora do prazo de opera��o";
                        case 24: return "24-Data de emiss�o Inv�lida";
                        case 26: return "26-C�digo de juros de mora inv�lido";
                        case 27: return "27-Valor/taxa de juros de mora inv�lido";
                        case 28: return "28-C�digo de desconto inv�lido";
                        case 29: return "29-Valor do desconto maior/igual ao valor do T�tulo";
                        case 30: return "30-Desconto a conceder n�o confere";
                        case 31: return "31-Concess�o de desconto j� existente ( Desconto anterior )";
                        case 32: return "32-Valor do IOF inv�lido";
                        case 33: return "33-Valor do abatimento inv�lido";
                        case 34: return "34-Valor do abatimento maior/igual ao valor do T�tulo";
                        case 38: return "38-Prazo para protesto inv�lido";
                        case 39: return "39-Pedido de protesto n�o permitido para o T�tulo";
                        case 40: return "40-T�tulo com ordem de protesto emitido";
                        case 42: return "42-C�digo para baixa/devolu��o inv�lido";
                        case 46: return "46-Tipo/n�mero de inscri��o do sacado inv�lidos";
                        case 48: return "48-Cep Inv�lido";
                        case 53: return "53-Tipo/N�mero de inscri��o do sacador/avalista inv�lidos";
                        case 54: return "54-Sacador/avalista n�o informado";
                        case 57: return "57-C�digo da multa inv�lido";
                        case 58: return "58-Data da multa inv�lida";
                        case 60: return "60-Movimento para T�tulo n�o cadastrado";
                        case 79: return "79-Data de Juros de mora Inv�lida";
                        case 80: return "80-Data do desconto inv�lida";
                        case 85: return "85-T�tulo com Pagamento Vinculado.";
                        case 88: return "88-E-mail Sacado n�o lido no prazo 5 dias";
                        case 91: return "91-E-mail sacado n�o recebido";
                        default: return string.Format("{0:00} - Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoComandoRecusado:
                    switch (codMotivo)
                    {
                        case 1: return "01-C�digo do Banco inv�lido";
                        case 2: return "02-C�digo do registro detalhe inv�lido";
                        case 4: return "04-C�digo de ocorr�ncia n�o permitido para a carteira";
                        case 5: return "05-C�digo de ocorr�ncia n�o num�rico";
                        case 7: return "07-Ag�ncia/Conta/d�gito inv�lidos";
                        case 08: return "08-Nosso n�mero inv�lido";
                        case 10: return "10-Carteira inv�lida";
                        case 15: return "15-Caracter�sticas da cobran�a incompat�veis";
                        case 16: return "16-Data de vencimento inv�lida";
                        case 17: return "17-Data de vencimento anterior a data de emiss�o";
                        case 18: return "18-Vencimento fora do prazo de opera��o";
                        case 20: return "20-Valor do t�tulo inv�lido";
                        case 21: return "21-Esp�cie do T�tulo inv�lida";
                        case 22: return "22-Esp�cie n�o permitida para a carteira";
                        case 24: return "24-Data de emiss�o inv�lida";
                        case 28: return "28-C�digo de desconto via Telebradesco inv�lido";
                        case 29: return "29-Valor do desconto maior/igual ao valor do T�tulo";
                        case 30: return "30-Desconto a conceder n�o confere";
                        case 31: return "31-Concess�o de desconto - J� existe desconto anterior";
                        case 33: return "33-Valor do abatimento inv�lido";
                        case 34: return "34-Valor do abatimento maior/igual ao valor do T�tulo";
                        case 36: return "36-Concess�o abatimento - J� existe abatimento anterior";
                        case 38: return "38-Prazo para protesto inv�lido";
                        case 39: return "39-Pedido de protesto n�o permitido para o T�tulo";
                        case 40: return "40-T�tulo com ordem de protesto emitido";
                        case 41: return "41-Pedido cancelamento/susta��o para T�tulo sem instru��o de protesto";
                        case 42: return "42-C�digo para baixa/devolu��o inv�lido";
                        case 45: return "45-Nome do Sacado n�o informado";
                        case 46: return "46-Tipo/n�mero de inscri��o do Sacado inv�lidos";
                        case 47: return "47-Endere�o do Sacado n�o informado";
                        case 48: return "48-CEP Inv�lido";
                        case 50: return "50-CEP referente a um Banco correspondente";
                        case 53: return "53-Tipo de inscri��o do sacador avalista inv�lidos";
                        case 60: return "60-Movimento para T�tulo n�o cadastrado";
                        case 85: return "85-T�tulo com pagamento vinculado";
                        case 86: return "86-Seu n�mero inv�lido";
                        case 94: return "94-T�tulo Penhorado � Instru��o N�o Liberada pela Ag�ncia";
                        default: return string.Format("{0:00} - Outros Motivos", codMotivo);
                    }

                case TipoOcorrencia.RetornoDesagendamentoDebitoAutomatico:
                    switch (codMotivo)
                    {
                        case 81: return "81-Tentativas esgotadas, baixado";
                        case 82: return "82-Tentativas esgotadas, pendente";
                        case 83: return "83-Cancelado pelo Sacado e Mantido Pendente, conforme negocia��o";
                        case 84: return "84-Cancelado pelo sacado e baixado, conforme negocia��o";   
                        default: return string.Format("{0:00} - Outros Motivos", codMotivo);
                    }

                default: return string.Format("{0:00} - Outros Motivos", codMotivo);
            }
        }

        /// <summary>
        /// Calculars the digito verificador.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException">Esta fun��o n�o esta implementada para este banco</exception>
        public override string CalcularDigitoVerificador(Titulo titulo)
        {
            Modulo.CalculoPadrao();
            Modulo.MultiplicadorFinal = 7;
            Modulo.Documento = titulo.Carteira + titulo.NossoNumero;
            Modulo.Calcular();
            
            if(Modulo.ModuloFinal == 1)
                return "P";
	        return Modulo.DigitoFinal.ToString();
        }

        /// <summary>
        /// Montars the campo codigo cedente.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <returns>System.String.</returns>
        /// <exception cref="System.NotImplementedException">Esta fun��o n�o esta implementada para este banco</exception>
        public override string MontarCampoCodigoCedente(Titulo titulo)
        {
            return String.Format("{0}-{1}/{2}-{3}", titulo.Parent.Cedente.Agencia, 
                titulo.Parent.Cedente.AgenciaDigito, titulo.Parent.Cedente.Conta, 
                titulo.Parent.Cedente.ContaDigito); 
        }

        /// <summary>
        /// Montar o campo nosso numero.
        /// </summary>
        /// <param name="titulo">Boleto</param>
        /// <returns>NossoNumero</returns>
        public override string MontarCampoNossoNumero(Titulo titulo)
        {
            return String.Format("{0}/{1}-{2}", titulo.Carteira, titulo.NossoNumero, CalcularDigitoVerificador(titulo));
        }

        /// <summary>
        /// Montar o codigo barras do boleto.
        /// </summary>
        /// <param name="titulo">Boleto.</param>
        /// <returns>Codigo de barras</returns>
        public override string MontarCodigoBarras(Titulo titulo)
        {
            var  fatorVencimento = titulo.Vencimento.CalcularFatorVencimento();
            var codigoBarras = string.Format("{0}9{1}{2}{3}{4}{5}{6}0", Numero, fatorVencimento, titulo.ValorDocumento.ToDecimalString(10),
                                titulo.Parent.Cedente.Agencia.OnlyNumbers().FillRight(TamanhoAgencia,'0'), titulo.Carteira, titulo.NossoNumero,
                                titulo.Parent.Cedente.Conta.Right(7).FillRight(7,'0'));
            
            var digitoCodBarras = CalcularDigitoCodigoBarras(codigoBarras);
            
            return codigoBarras.Insert(4, digitoCodBarras);
        }

        /// <summary>
        /// Montar a linha digitavel do boleto.
        /// </summary>
        /// <param name="codigoBarras">Codigo de barras.</param>
        /// <param name="titulo">Boleto.</param>
        /// <returns>Linha digitavel</returns>
        public override string MontarLinhaDigitavel(string codigoBarras, Titulo titulo)
        {
            Modulo.FormulaDigito = CalcDigFormula.Modulo10;
            Modulo.MultiplicadorInicial = 1;
            Modulo.MultiplicadorFinal = 2;
            Modulo.MultiplicadorAtual = 2;

            //Campo 1(C�digo Banco,Tipo de Moeda,5 primeiro digitos do Campo Livre)
            Modulo.Documento = string.Format("{0}9{1}", codigoBarras.Substring(1, 3), codigoBarras.Substring(19, 5));
            Modulo.Calcular();

            var campo1 = string.Format("{0}.{1}{2}", Modulo.Documento.Substring(0, 5), Modulo.Documento.Substring(5, 4), Modulo.DigitoFinal);

            //Campo 2(6� a 15� posi��es do campo Livre)
            Modulo.Documento = codigoBarras.Substring(24, 10);
            Modulo.Calcular();

            var campo2 = string.Format("{0}.{1}{2}", Modulo.Documento.Substring(0, 5), Modulo.Documento.Substring(5, 5), Modulo.DigitoFinal);

            //Campo 3 (16� a 25� posi��es do campo Livre)
            Modulo.Documento = codigoBarras.Substring(34, 10);
            Modulo.Calcular();

            var campo3 = string.Format("{0}.{1}{2}", Modulo.Documento.Substring(0, 5), Modulo.Documento.Substring(5, 5), Modulo.DigitoFinal);

            //Campo 4 (Digito Verificador Nosso Numero)
            var campo4 = codigoBarras.Substring(4, 1);

            //Campo 5 (Fator de Vencimento e Valor do Documento)
            var campo5 = codigoBarras.Substring(5, 14);

            return string.Format("{0} {1} {2} {3} {4}", campo1, campo2, campo3, campo4, campo5);
        }

        /// <summary>
        /// Gerars the registro header400.
        /// </summary>
        /// <param name="numeroRemessa">The numero remessa.</param>
        /// <param name="aRemessa">A remessa.</param>
        /// <exception cref="System.NotImplementedException">Esta fun��o n�o esta implementada para este banco</exception>
        public override void GerarRegistroHeader400(int numeroRemessa, List<string> aRemessa)
        {
            var ced = Banco.Parent.Cedente;
            var wLinha = new StringBuilder();
            wLinha.Append('0');                                                      // ID do Registro
            wLinha.Append('1');                                                      // ID do Arquivo( 1 - Remessa)
            wLinha.Append("REMESSA");                                                // Literal de Remessa
            wLinha.Append("01");                                                     // C�digo do Tipo de Servi�o
            wLinha.Append("COBRANCA".FillLeft(15));                                   // Descri��o do tipo de servi�o
            wLinha.Append(ced.CodigoCedente.FillRight(20, '0'));                      // Codigo da Empresa no Banco
            wLinha.Append(ced.Nome.RemoveCe().FillLeft(30));                          // Nome da Empresa
            wLinha.Append(Numero + "BRADESCO".FillLeft(15));                          // C�digo e Nome do Banco(237 - Bradesco)
            wLinha.AppendFormat("{0:ddMMyy}        MX", DateTime.Now);               // Data de gera��o do arquivo + brancos
            wLinha.AppendFormat("{0:0000000}{1}", numeroRemessa, "".FillRight(277));  // Nr. Sequencial de Remessa + brancos
            wLinha.AppendFormat("{0:000000}", 1);                                    // Nr. Sequencial de Remessa + brancos + Contador
            aRemessa.Add(wLinha.ToString().ToUpper());
        }

        /// <summary>
        /// Gerars the registro transacao400.
        /// </summary>
        /// <param name="titulo">The titulo.</param>
        /// <param name="aRemessa">A remessa.</param>
        public override void GerarRegistroTransacao400(Titulo titulo, List<string> aRemessa)
        {
            string aCarteira = string.Empty;
            string aAgencia = string.Empty;
            string aConta = string.Empty;
            string digitoNossoNumero = string.Empty;

            var doMontaInstrucoes = new Func<string>(() =>
            {
                var result = new StringBuilder();
                result.Append("");

                //Primeira instru��o vai no registro 1
                if (titulo.Mensagem.Count <= 1)
                    return string.Empty;

                result.Append(Environment.NewLine);
                result.Append('2');                                     // IDENTIFICA��O DO LAYOUT PARA O REGISTRO
                result.Append(titulo.Mensagem[1].FillLeft(80));          // CONTE�DO DA 1� LINHA DE IMPRESS�O DA �REA "INSTRU��ES� DO BOLETO

                if (titulo.Mensagem.Count == 3)
                    result.Append(titulo.Mensagem[2].FillLeft(80));      // CONTE�DO DA 2� LINHA DE IMPRESS�O DA �REA "INSTRU��ES� DO BOLETO
                else
                    result.Append("".FillLeft(80));                      // CONTE�DO DO RESTANTE DAS LINHAS

                if (titulo.Mensagem.Count == 4)
                    result.Append(titulo.Mensagem[3].FillLeft(80));      // CONTE�DO DA 3� LINHA DE IMPRESS�O DA �REA "INSTRU��ES� DO BOLETO
                else
                    result.Append("".FillLeft(80));                      // CONTE�DO DO RESTANTE DAS LINHAS

                if (titulo.Mensagem.Count == 5)
                    result.Append(titulo.Mensagem[4].FillLeft(80));      // CONTE�DO DA 4� LINHA DE IMPRESS�O DA �REA "INSTRU��ES� DO BOLETO
                else
                    result.Append("".FillLeft(80));                      // CONTE�DO DO RESTANTE DAS LINHAS


                result.Append("".FillRight(45));                         // COMPLEMENTO DO REGISTRO
                result.Append(aCarteira);
                result.Append(aAgencia);
                result.Append(aConta);
                result.Append(titulo.Parent.Cedente.ContaDigito);
                result.Append(titulo.NossoNumero);
                result.Append(digitoNossoNumero);
                result.AppendFormat("{0:000000}", aRemessa.Count + 2);
                return result.ToString();
            });

            digitoNossoNumero = CalcularDigitoVerificador(titulo);
            aAgencia = titulo.Parent.Cedente.Agencia.OnlyNumbers().ZeroFill(5);
            aConta = titulo.Parent.Cedente.Conta.OnlyNumbers().ZeroFill(7);
            aCarteira = titulo.Carteira.Trim().ZeroFill(3);

            //Pegando C�digo da Ocorrencia
            string ocorrencia;
            switch (titulo.OcorrenciaOriginal.Tipo)
            {
                case TipoOcorrencia.RemessaBaixar:
                    ocorrencia = "02"; //Pedido de Baixa
                    break;

                case TipoOcorrencia.RemessaConcederAbatimento:
                    ocorrencia = "04"; //Concess�o de Abatimento
                    break;

                case TipoOcorrencia.RemessaCancelarAbatimento:
                    ocorrencia = "05"; //Cancelamento de Abatimento concedido
                    break;

                case TipoOcorrencia.RemessaAlterarVencimento:
                    ocorrencia = "06"; //Altera��o de vencimento
                    break;

                case TipoOcorrencia.RemessaAlterarNumeroControle:
                    ocorrencia = "08"; //Altera��o de seu n�mero
                    break;

                case TipoOcorrencia.RemessaProtestar:
                    ocorrencia = "09"; //Pedido de protesto
                    break;

                case TipoOcorrencia.RemessaCancelarInstrucaoProtestoBaixa:
                    ocorrencia = "18"; //Sustar protesto e baixar
                    break;

                case TipoOcorrencia.RemessaCancelarInstrucaoProtesto:
                    ocorrencia = "19"; //Sustar protesto e manter na carteira
                    break;

                case TipoOcorrencia.RemessaOutrasOcorrencias:
                    ocorrencia = "31"; //Altera��o de Outros Dados
                    break;

                default:
                    ocorrencia = "01"; //Remessa
                    break;
            }

            //Pegando Tipo de Boleto
            string tipoBoleto;
            switch (titulo.Parent.Cedente.ResponEmissao)
            {
                case ResponEmissao.CliEmite:
                    tipoBoleto = "2";
                    break;

                default:
                    tipoBoleto = "1";
                    if (string.IsNullOrEmpty(titulo.NossoNumero))
                        digitoNossoNumero = "0";
                    break;
            }

            string aEspecie;
            switch (titulo.EspecieDoc.Trim())
            {
                case "DM":
                    aEspecie = "01";
                    break;

                case "NP":
                    aEspecie = "02";
                    break;

                case "NS":
                    aEspecie = "03";
                    break;

                case "CS":
                    aEspecie = "04";
                    break;

                case "ND":
                    aEspecie = "11";
                    break;

                case "DS":
                    aEspecie = "12";
                    break;

                case "OU":
                    aEspecie = "99";
                    break;

                default:
                    aEspecie = titulo.EspecieDoc;
                    break;
            }

            //Pegando campo Intru��es
            string protesto;
            if (titulo.DataProtesto.HasValue && titulo.DataProtesto > titulo.Vencimento)
                protesto = "06" + (titulo.DataProtesto.Value - titulo.Vencimento).TotalDays.ToString().ZeroFill(2);
            else if (ocorrencia == "31")
                protesto = "9999";
            else
                protesto = titulo.Instrucao1.Trim().FillRight(2, '0') + titulo.Instrucao2.Trim().FillRight(2, '0');

            //Pegando Tipo de Sacado
            string tipoSacado;
            switch (titulo.Sacado.Pessoa)
            {
                case Pessoa.Fisica:
                    tipoSacado = "01";
                    break;

                case Pessoa.Juridica:
                    tipoSacado = "02";
                    break;

                default:
                    tipoSacado = "99";
                    break;
            }

            string mensagemCedente;
            if (titulo.Mensagem.Count > 0)
                mensagemCedente = titulo.Mensagem[0];
            else
                mensagemCedente = string.Empty;

            var wLinha = new StringBuilder();
            wLinha.Append('1');                                                       // ID Registro
            wLinha.Append("".ZeroFill(19));                                    // Dados p/ D�bito Autom�tico
            wLinha.Append('0' + aCarteira);
            wLinha.Append(aAgencia);
            wLinha.Append(aConta);
            wLinha.Append(titulo.Parent.Cedente.ContaDigito);
            wLinha.Append(titulo.SeuNumero.FillLeft(25) + "000");             // Numero de Controle do Participante
            wLinha.Append(titulo.PercentualMulta > 0 ? '2' : '0');          // Indica se exite Multa ou n�o
            wLinha.Append(titulo.PercentualMulta.ToDecimalString(4));          // Percentual de Multa formatado com 2 casas decimais
            wLinha.Append(titulo.NossoNumero + digitoNossoNumero);
            wLinha.Append(titulo.ValorDescontoAntDia.ToDecimalString(10));
            wLinha.AppendFormat("{0} {1}", tipoBoleto, "".FillRight(10));                              // Tipo Boleto(Quem emite) + Identifica��o se emite boleto para d�bito autom�tico.                  
            wLinha.AppendFormat(" 2  {0}", ocorrencia);                             // Ind. Rateio de Credito + Aviso de Debito Aut.: 2=N�o emite aviso + Ocorr�ncia
            wLinha.Append(titulo.NumeroDocumento.FillLeft(10));
            wLinha.AppendFormat("{0:ddMMyy}", titulo.Vencimento);
            wLinha.Append(titulo.ValorDocumento.ToDecimalString());
            wLinha.AppendFormat("{0}{1}N", "".ZeroFill(8), aEspecie.FillLeft(2));     // Zeros + Especie do documento + Idntifica��o(valor fixo N)
            wLinha.AppendFormat("{0:ddMMyy}", titulo.DataDocumento);                 // Data de Emiss�o
            wLinha.Append(protesto);
            wLinha.Append(titulo.ValorMoraJuros.ToDecimalString());
            wLinha.Append(titulo.DataDesconto.HasValue && titulo.DataDesconto < new DateTime(2000, 01, 01) ?
                "000000" : string.Format("{0:ddMMyy}", titulo.DataDesconto.Value));
            wLinha.Append(titulo.ValorDesconto.ToDecimalString());
            wLinha.Append(titulo.ValorIOF.ToDecimalString());
            wLinha.Append(titulo.ValorAbatimento.ToDecimalString());
            wLinha.Append(tipoSacado + titulo.Sacado.CNPJCPF.OnlyNumbers().FillRight(14, '0'));
            wLinha.Append(titulo.Sacado.NomeSacado.FillLeft(40));
            wLinha.Append((titulo.Sacado.Logradouro + ' ' + titulo.Sacado.Numero + ' ' +
                    titulo.Sacado.Bairro + ' ' + titulo.Sacado.Cidade + ' ' +
                    titulo.Sacado.UF).FillLeft(40));
            wLinha.Append("".FillRight(12) + titulo.Sacado.CEP.FillLeft(8));
            wLinha.Append(mensagemCedente.FillLeft(60));


            wLinha.AppendFormat("{0:000000}", aRemessa.Count + 1); // N� SEQ�ENCIAL DO REGISTRO NO ARQUIVO
            wLinha.Append(doMontaInstrucoes());

            aRemessa.Add(wLinha.ToString().ToUpper());
        }

        /// <summary>
        /// Gera o registro trailler para o formato CNAB400.
        /// </summary>
        /// <param name="aRemessa">Dados da remessa</param>
        /// <exception cref="System.NotImplementedException">Esta fun��o n�o esta implementada para este banco</exception>
        public override void GerarRegistroTrailler400(List<string> aRemessa)
        {
            var wLinha = new StringBuilder();
            wLinha.Append('9');
            wLinha.Append("".FillRight(393));                        // ID Registro
            wLinha.AppendFormat("{0:000000}", aRemessa.Count + 1);  // Contador de Registros
            aRemessa.Add(wLinha.ToString().ToUpper());
        }

        /// <summary>
        /// Ler retorno de arquivo CNAB400.
        /// </summary>
        /// <param name="aRetorno">Dados do retorno.</param>
        /// <exception cref="ACBrException">C�digo da Empresa do arquivo inv�lido
        /// or
        /// Agencia\\Conta do arquivo inv�lido</exception>
        public override void LerRetorno400(List<string> aRetorno)
        {
            if(aRetorno[0].ExtrairInt32DaPosicao(77,79) != Numero)
                throw new ACBrException(string.Format("{0} n�o � um arquivo de retorno do {1}",
                                                       Banco.Parent.NomeArqRetorno, Nome));
            
            var rCodEmpresa = aRetorno[0].ExtrairDaPosicao(27, 46).Trim();
            var rCedente = aRetorno[0].ExtrairDaPosicao(47, 76).Trim();
            var rAgencia = aRetorno[1].ExtrairDaPosicao( 25, 29).Trim();
            var rConta   = aRetorno[1].ExtrairDaPosicao( 30, 36).Trim();
            var rDigitoConta = aRetorno[1].ExtrairDaPosicao(37, 37);
            
            Banco.Parent.NumeroArquivo = aRetorno[0].ExtrairInt32DaPosicao(109, 113);            
            Banco.Parent.DataArquivo = aRetorno[0].ExtrairDataDaPosicao(95, 100);
            Banco.Parent.DataCreditoLanc = aRetorno[0].ExtrairDataDaPosicao(380, 385);
            
            string rCNPJCPF;
            switch(aRetorno[1].ExtrairInt32DaPosicao(2, 3))
            {
                case 11:
                    rCNPJCPF = aRetorno[1].ExtrairDaPosicao(4, 14);
                    break;

                case 14:
                    rCNPJCPF = aRetorno[1].ExtrairDaPosicao(4, 17);
                    break;

                default:
                    rCNPJCPF = aRetorno[1].ExtrairDaPosicao(4, 17);
                    break;
            }

            if(!Banco.Parent.LeCedenteRetorno)
            {
                if (rCodEmpresa != Banco.Parent.Cedente.CodigoCedente.FillRight(20, '0'))
                    throw new ACBrException("C�digo da Empresa do arquivo inv�lido");
                
                if (rAgencia != Banco.Parent.Cedente.Agencia.OnlyNumbers() ||
                    rConta != Banco.Parent.Cedente.Conta.FillRight(rConta.Length))
                    throw new ACBrException("Agencia\\Conta do arquivo inv�lido");
            }
            
            switch(aRetorno[1].ExtrairInt32DaPosicao(2, 3))
            {
                case 11:
                    Banco.Parent.Cedente.TipoInscricao = PessoaCedente.Fisica;
                    break;

                case 14:
                    Banco.Parent.Cedente.TipoInscricao = PessoaCedente.Juridica;
                    break;

                default:
                    Banco.Parent.Cedente.TipoInscricao = PessoaCedente.Juridica;
                    break;
            }
            
            if(Banco.Parent.LeCedenteRetorno)
            {
                Banco.Parent.Cedente.CNPJCPF = rCNPJCPF;
                Banco.Parent.Cedente.CodigoCedente = rCodEmpresa;
                Banco.Parent.Cedente.Nome = rCedente;
                Banco.Parent.Cedente.Agencia = rAgencia;
                Banco.Parent.Cedente.AgenciaDigito = "0";
                Banco.Parent.Cedente.Conta = rConta;
                Banco.Parent.Cedente.ContaDigito = rDigitoConta;
            }
            
            Banco.Parent.ListadeBoletos.Clear();
            string linha;
            Titulo titulo;
            for(int contLinha = 1; contLinha < aRetorno.Count - 1; contLinha++)
            {
                linha = aRetorno[contLinha];
                
                if (linha.ExtrairInt32DaPosicao(1,1) == 1)
                    continue;
                
                titulo = Banco.Parent.CriarTituloNaLista();

                
                titulo.SeuNumero = linha.ExtrairDaPosicao(38, 62);
                titulo.NumeroDocumento = linha.ExtrairDaPosicao(117, 126);
                titulo.OcorrenciaOriginal.Tipo = CodOcorrenciaToTipo(linha.ExtrairInt32DaPosicao(109, 110));
                
                var codOcorrencia = linha.ExtrairInt32DaPosicao(109,2);
                
                //-|Se a ocorrencia for igual a 19 - Confirma��o de Receb. de Protesto
                //-|Verifica o motivo na posi��o 295 - A = Aceite , D = Desprezado
                if(codOcorrencia == 19)
                {
                    var codMotivo19 = linha.ExtrairDaPosicao(295, 295);
                    titulo.MotivoRejeicaoComando.Add(linha.ExtrairDaPosicao(295, 295).ZeroFill(2));
                    if(codMotivo19 == "A")
                        titulo.DescricaoMotivoRejeicaoComando.Add("A - Aceito");
                    else
                        titulo.DescricaoMotivoRejeicaoComando.Add("D - Desprezado");
                }
                else
                {
                    var motivoLinha = 319;
                    for(int i = 0; i < 4; i++)
                    {
                        var codMotivo =  linha.ExtrairInt32DaPosicao(motivoLinha, motivoLinha + 1);
                        
                        //Se for o primeiro motivo}
                        if (i == 0) 
                        {
                            //Somente estas ocorrencias possuem motivos 00}
                            if(codOcorrencia.IsIn( 2, 6, 9, 10, 15, 17))
                            {
                                titulo.MotivoRejeicaoComando.Add(linha.ExtrairDaPosicao(motivoLinha, motivoLinha + 1).ZeroFill(2));
                                titulo.DescricaoMotivoRejeicaoComando.Add(CodMotivoRejeicaoToDescricao(titulo.OcorrenciaOriginal.Tipo, codMotivo));
                            }
                            else
                            {
                                if(codMotivo == 0)
                                {
                                    titulo.MotivoRejeicaoComando.Add("00");
                                    titulo.DescricaoMotivoRejeicaoComando.Add("Sem Motivo");
                                }
                                else
                                {
                                    titulo.MotivoRejeicaoComando.Add(linha.ExtrairDaPosicao(motivoLinha, motivoLinha + 1).ZeroFill(2));
                                    titulo.DescricaoMotivoRejeicaoComando.Add(CodMotivoRejeicaoToDescricao(titulo.OcorrenciaOriginal.Tipo, codMotivo));
                                }
                            }
                        }
                        else
                        {
                            //Apos o 1� motivo os 00 significam que n�o existe mais motivo
                            if(codMotivo != 0)
                            {
                                titulo.MotivoRejeicaoComando.Add(linha.ExtrairDaPosicao(motivoLinha, motivoLinha + 1).ZeroFill(2));
                                titulo.DescricaoMotivoRejeicaoComando.Add(CodMotivoRejeicaoToDescricao(titulo.OcorrenciaOriginal.Tipo, codMotivo));
                            }
                        }

                        motivoLinha = motivoLinha + 2; //Incrementa a coluna dos motivos
                    }
                    
                    titulo.DataOcorrencia = linha.ExtrairDataDaPosicao(111, 116);
                    var temp = linha.ExtrairDataOpcionalDaPosicao(147, 152);
                    if(temp.HasValue)
                        titulo.Vencimento = temp.Value;

                    titulo.ValorDocumento = linha.ExtrairDecimalDaPosicao(153, 165);
                    titulo.ValorIOF = linha.ExtrairDecimalDaPosicao(215, 227);
                    titulo.ValorAbatimento = linha.ExtrairDecimalDaPosicao(228, 240);
                    titulo.ValorDesconto = linha.ExtrairDecimalDaPosicao(241, 253);
                    titulo.ValorRecebido = linha.ExtrairDecimalDaPosicao(254, 266);
                    titulo.ValorMoraJuros = linha.ExtrairDecimalDaPosicao(267, 279);
                    titulo.ValorOutrosCreditos = linha.ExtrairDecimalDaPosicao(280, 292);
                    titulo.NossoNumero = linha.ExtrairDaPosicao(71, 80);
                    titulo.Carteira = linha.ExtrairDaPosicao(22, 24);
                    titulo.ValorDespesaCobranca = linha.ExtrairDecimalDaPosicao(176, 188);
                    titulo.ValorOutrasDespesas = linha.ExtrairDecimalDaPosicao(189, 201);
                    
                    var temp2 = linha.ExtrairDataOpcionalDaPosicao(296, 301);
                    if (temp2.HasValue)
                        titulo.DataCredito = temp2.Value;
                }                                        
            }
        }

        #endregion Methods
    }    
}
