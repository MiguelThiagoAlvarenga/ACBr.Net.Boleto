// ***********************************************************************
// Assembly         : ACBr.Net.Boleto
// Author           : RFTD
// Created          : 05-30-2014
//
// Last Modified By : RFTD
// Last Modified On : 06-14-2014
// ***********************************************************************
// <copyright file="BancoHSBC.cs" company="ACBr.Net">
//     Copyright (c) ACBr.Net. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ACBr.Net.Boleto.Enums;
using ACBr.Net.Boleto.Utils;
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
	[Guid("6E5BD577-1A64-41A7-BA76-8D9BF00777CE")]
	[ClassInterface(ClassInterfaceType.AutoDual)]

#endif

	#endregion COM Interop Attributes
	/// <summary>
	/// Classe BancoHSBC. Esta classe n�o pode ser herdada.
	/// </summary>
    public sealed class BancoHSBC : BancoBase
    {
        #region Fields
        #endregion Fields

        #region Constructor

		/// <summary>
		/// Inicializa uma nova instancia da classe <see cref="BancoHSBC" />.
		/// </summary>
		/// <param name="parent">Classe Banco.</param>
		internal BancoHSBC(Banco parent)
			: base(parent)
        {
            TipoCobranca = TipoCobranca.HSBC;
			Digito = 9;
			Nome = "HSBC";
			Numero = 399;
			TamanhoMaximoNossoNum = 16;
			TamanhoAgencia = 4;
			TamanhoConta = 7;
			TamanhoCarteira = 3;
        }

        #endregion Constructor

        #region Propriedades
        #endregion Propriedades

        #region Methods

		/// <summary>
		/// Informa a descri��o do tipo de ocorrencia informado.
		/// </summary>
		/// <param name="tipo">Tipo de ocorrencia</param>
		/// <returns>Descri��o da ocorrencia</returns>
        public override string TipoOcorrenciaToDescricao(TipoOcorrencia tipo)
        {
            var codOcorrencia = TipoOCorrenciaToCod(tipo).ToInt32();
            switch (codOcorrencia)
            {
				case 2: return "02-Entrada Confirmada";
				case 3: return "03-Entrada Rejeitada";
				case 6: return "06-Liquida��o normal";
				case 9: return "09-Baixado Automaticamente via Arquivo";
				case 10: return "10-Baixado conforme instru��es da Ag�ncia";
				case 11: return "11-Em Ser - Arquivo de T�tulos pendentes";
				case 12: return "12-Abatimento Concedido";
				case 13: return "13-Abatimento Cancelado";
				case 14: return "14-Vencimento Alterado";
				case 15: return "15-Liquida��o em Cart�rio";
				case 16: return "16-Titulo Pago em Cheque - Vinculado";
				case 17: return "17-Liquida��o ap�s baixa ou T�tulo n�o registrado";
				case 18: return "18-Acerto de Deposit�ria";
				case 19: return "19-Confirma��o Recebimento Instru��o de Protesto";
				case 20: return "20-Confirma��o Recebimento Instru��o Susta��o de Protesto";
				case 21: return "21-Acerto do Controle do Participante";
				case 22: return "22-Titulo com Pagamento Cancelado";
				case 23: return "23-Entrada do T�tulo em Cart�rio";
				case 24: return "24-Entrada rejeitada por CEP Irregular";
				case 27: return "27-Baixa Rejeitada";
				case 28: return "28-D�bito de tarifas/custas";
				case 29: return "29-Ocorr�ncias do Sacado";
				case 30: return "30-Altera��o de Outros Dados Rejeitados";
				case 32: return "32-Instru��o Rejeitada";
				case 33: return "33-Confirma��o Pedido Altera��o Outros Dados";
				case 34: return "34-Retirado de Cart�rio e Manuten��o Carteira";
				case 35: return "35-Desagendamento do d�bito autom�tico";
				case 40: return "40-Estorno de Pagamento";
				case 55: return "55-Sustado Judicial";
				case 68: return "68-Acerto dos dados do rateio de Cr�dito";
				case 69: return "69-Cancelamento dos dados do rateio";
                default: return string.Format("{0:00}-Outras Ocorrencias", codOcorrencia);
			}
        }

		/// <summary>
		/// Transforma um codigo de ocorrencia em um Tipo de ocorrencia.
		/// </summary>
		/// <param name="codOcorrencia">Codigo da ocorrencia.</param>
		/// <returns>Retorna um TipoOcorrencia.</returns>
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
				case 16: return TipoOcorrencia.RetornoLiquidado;
				case 17: return TipoOcorrencia.RetornoLiquidadoAposBaixaOuNaoRegistro;
				case 18: return TipoOcorrencia.RetornoAcertoDepositaria;
				case 19: return TipoOcorrencia.RetornoRecebimentoInstrucaoProtestar;
				case 20: return TipoOcorrencia.RetornoRecebimentoInstrucaoSustarProtesto;
				case 21: return TipoOcorrencia.RetornoAcertoControleParticipante;
				case 22: return TipoOcorrencia.RetornoRecebimentoInstrucaoAlterarDados;
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
				case TipoOcorrencia.RetornoRecebimentoInstrucaoAlterarDados: return "22";
				case TipoOcorrencia.RetornoEncaminhadoACartorio: return "23";
				case TipoOcorrencia.RetornoEntradaRejeitaCEPIrregular: return "24";
				case TipoOcorrencia.RetornoBaixaRejeitada: return "27";
				case TipoOcorrencia.RetornoDebitoTarifas: return "28";
				case TipoOcorrencia.RetornoOcorrenciasDoSacado: return "29";
				case TipoOcorrencia.RetornoAlteracaoOutrosDadosRejeitada: return "30";
				case TipoOcorrencia.RetornoComandoRecusado: return "32";
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
						case 9: return "Nosso numero duplicado";
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

				case TipoOcorrencia.RetornoLiquidadoEmCartorio:
				case TipoOcorrencia.RetornoLiquidadoAposBaixaOuNaoRegistro:
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
						case 10: return "10=Baixa comandada pelo cliente";
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
						case 07: return "07-Agencia\\Conta\\Digito invalidos";
						case 08: return "08-Nosso numero invalido";
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
						case 03: return "03-Tarifa de susta��o";
						case 04: return "04-Tarifa de protesto";
						case 05: return "05-Tarifa de outras instrucoes";
						case 06: return "06-Tarifa de outras ocorr�ncias";
						case 08: return "08-Custas de protesto";
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
						case 02: return "02-C�digo do registro detalhe inv�lido";
						case 04: return "04-C�digo de ocorr�ncia n�o permitido para a carteira";
						case 05: return "05-C�digo de ocorr�ncia n�o num�rico";
						case 07: return "07-Ag�ncia/Conta/d�gito inv�lidos";
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
        public override string CalcularDigitoVerificador(Titulo titulo)
        {
			var calcularDigito = new Func<string, string>(aNumero =>
			{
				Modulo.CalculoPadrao();
				Modulo.Documento = aNumero.Trim();
				Modulo.Calcular();

				return Modulo.DigitoFinal.ToString();
			});

			// numero base para o calculo do primeiro e segundo digitos
			var aNumeroDoc = titulo.NossoNumero.Right(13).ZeroFill(13);

			// Calculo do primeiro digito
			var aNumeroBase = aNumeroDoc;
			var aDigito = calcularDigito(aNumeroDoc);
			var aDigito1 = aDigito + "4";

			// calculo do segundo digito
			var vencimento = titulo.Vencimento.ToString("ddMMyy");
			var cedente = Banco.Parent.Cedente.CodigoCedente.ToDecimal();
			var numero  = (aNumeroBase + aDigito1).ToDecimal();
			
			aNumeroBase = numero + cedente + vencimento;
			var aDigito2  = calcularDigito(aNumeroBase);

			var ret = aDigito1 + aDigito2;

            return ret;
        }

		/// <summary>
		/// Calculars the tam maximo nosso numero.
		/// </summary>
		/// <param name="carteira">The carteira.</param>
		/// <param name="nossoNumero">The nosso numero.</param>
		/// <returns>System.Int32.</returns>
		/// <exception cref="ACBrException">HSBC requer que o Conv�nio do Cedente seja informado.
		/// or
		/// HSBC requer que a carteira seja informada antes do Nosso N�mero.</exception>
		/// <exception cref="ACBrException">HSBC requer que o Conv�nio do Cedente seja informado.
		/// or
		/// HSBC requer que a carteira seja informada antes do Nosso N�mero.</exception>
        public override int CalcularTamMaximoNossoNumero(string carteira, string nossoNumero = "")
        {
            var ret = TamanhoMaximoNossoNum;
			
			Guard.Against<ACBrException>(carteira.IsEmpty(), "Banco HSBC requer que a carteira seja informada antes do Nosso N�mero.");

			if (carteira.Trim() != "CSB" && carteira.Trim() != "1") 
				return ret;

			ret = 5;
			TamanhoMaximoNossoNum = 5;

			return ret;
		}

		/// <summary>
		/// Montars the campo codigo cedente.
		/// </summary>
		/// <param name="titulo">The titulo.</param>
		/// <returns>System.String.</returns>
        public override string MontarCampoCodigoCedente(Titulo titulo)
		{
			if (titulo.Carteira.Trim() == "CSB" || titulo.Carteira.Trim() == "1")
				return string.Format("{0}-{1}", titulo.Parent.Cedente.Agencia, titulo.Parent.Cedente.CodigoCedente);
			
			return titulo.Parent.Cedente.CodigoCedente;
		}

		/// <summary>
		/// Montars the campo nosso numero.
		/// </summary>
		/// <param name="titulo">The titulo.</param>
		/// <returns>System.String.</returns>
		public override string MontarCampoNossoNumero(Titulo titulo)
		{
			if (titulo.Carteira.Trim() == "CSB" || titulo.Carteira.Trim() == "1")
			{
				var wNossoNumero = titulo.NossoNumero.Length < 6 ?
					string.Format("{0}{1}", titulo.Parent.Cedente.Convenio.ZeroFill(5), 
					titulo.NossoNumero.Right(5)) : titulo.NossoNumero.Right(10);

				Modulo.CalculoPadrao();
				Modulo.MultiplicadorFinal = 7;
				Modulo.Documento = wNossoNumero;
				Modulo.Calcular();

				return wNossoNumero.Right(10) + Modulo.DigitoFinal;
			}
			
			return string.Format("{0}-{1}", titulo.NossoNumero, CalcularDigitoVerificador(titulo));
		}

		/// <summary>
		/// Montars the codigo barras.
		/// </summary>
		/// <param name="titulo">The titulo.</param>
		/// <returns>System.String.</returns>
		/// <exception cref="ACBrException">Carteira Inv�lida.\r\nUtilize \CSB\, \CNR\, \1\ ou \2\</exception>
        public override string MontarCodigoBarras(Titulo titulo)
        {
			var aCarteira = string.Empty;
            if (titulo.Carteira == "CSB")
				aCarteira = "1";
			else if(titulo.Carteira == "CNR")
				aCarteira = "2";
			else if (titulo.Carteira != "1" && titulo.Carteira != "2")
				throw new ACBrException("Carteira Inv�lida.\r\nUtilize \"CSB\", \"CNR\", \"1\" ou \"2\"") ;

			var aNossoNumero = MontarCampoNossoNumero(titulo);

			var parte1 = titulo.Parent.Banco.Numero + "9";
			string parte2;

			if (aCarteira == "1")
			{
				//CSB' Cobranca Registrada
				parte2 = string.Format("{0}{1}{2}{3}{4}00", titulo.Vencimento.CalcularFatorVencimento(),
				   titulo.ValorDocumento.ToDecimalString(10), aNossoNumero.ZeroFill(13).Right(11),       // precisa passar nosso numero + digito
				   titulo.Parent.Cedente.Agencia.ZeroFill(4), titulo.Parent.Cedente.Conta[1] == '0' ?
				   titulo.Parent.Cedente.Conta.OnlyNumbers().Right(6) + titulo.Parent.Cedente.ContaDigito :
				   titulo.Parent.Cedente.Conta.OnlyNumbers().ZeroFill(7));
			}
			else
			{
				//'CNR' Cobranca Nao Registrada
				parte2 = string.Format("{0}{1}{2}{3}{4}", titulo.Vencimento.CalcularFatorVencimento(),
				   titulo.ValorDocumento.ToDecimalString(10), titulo.Parent.Cedente.CodigoCedente.Trim().ZeroFill(7),
				   aNossoNumero.Right(13).ZeroFill(13), titulo.Vencimento.ToJulianDate());
			}

			parte2 += aCarteira;
			var digito = CalcularDigitoCodigoBarras(parte1 + parte2);

			return string.Format("{0}{1}{2}", parte1, digito, parte2);
		}

		/// <summary>
		/// Gerars the registro header400.
		/// </summary>
		/// <param name="numeroRemessa">The numero remessa.</param>
		/// <param name="aRemessa">A remessa.</param>
        public override void GerarRegistroHeader400(int numeroRemessa, List<string> aRemessa)
        {
            var aAgencia = Banco.Parent.Cedente.Agencia.OnlyNumbers().ZeroFill(4);
            var aConta  = Banco.Parent.Cedente.Conta.OnlyNumbers();
			aConta = (aConta + Banco.Parent.Cedente.ContaDigito).ZeroFill(11);

            var wLinha = new StringBuilder();
            wLinha.Append('0');                                             // ID do Registro
            wLinha.Append('1');                                             // ID do Arquivo( 1 - Remessa)
            wLinha.Append("REMESSA");                                       // Literal de Remessa
            wLinha.Append("01");                                            // C�digo do Tipo de Servi�o
            wLinha.Append("COBRANCA".FillLeft(15));                         // Descri��o do tipo de servi�o
			wLinha.Append("0");										        // Zero
            wLinha.Append(aAgencia);                                        // Agencia cedente
            wLinha.Append("55");								            // Sub-Conta
            wLinha.Append(aConta);                                          // Conta Corrente 
            wLinha.Append("".FillLeft(2));                                  // Uso do banco
            wLinha.Append(Banco.Parent.Cedente.Nome.FillLeft(30));          // Nome da Empresa
            wLinha.Append("399");                                           // N�mero do Banco na compensa��o
            wLinha.Append("HSBC".FillLeft(15));                             // Nome do Banco por extenso
            wLinha.AppendFormat("{0:ddMMyy}",DateTime.Now);                 // Data de gera��o do arquivo
            wLinha.Append("01600");                                         // Densidade de grava��o
            wLinha.Append("BPI");                                           // Literal  Densidade
            wLinha.Append("".FillLeft(2));                                  // Uso do banco
            wLinha.Append("LANCV08");                                       // Sigla Layout
            wLinha.Append("".FillLeft(277));                                // Uso do Banco
            wLinha.Append("000001");                                        // Nr. Sequencial do registro-informar 000001

            aRemessa.Add(wLinha.ToString().ToUpper());

        }

		/// <summary>
		/// Gerars the registro transacao400.
		/// </summary>
		/// <param name="titulo">The titulo.</param>
		/// <param name="aRemessa">A remessa.</param>
		public override void GerarRegistroTransacao400(Titulo titulo, List<string> aRemessa)
		{
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
					ocorrencia = "05"; //Cancelamento de Abatimento concedido}
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
					ocorrencia = "19"; //Altera��o de nome e endere�o do Sacado
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
					tipoBoleto = " ";
					break;

				default:
					tipoBoleto = "S";
					break;
			}

			//Pegando o tipo de EspecieDoc
			string aEspecie;
			switch (titulo.EspecieDoc.Trim())
			{
				case "DP":
					aEspecie = "01";
					break;

				case "NP":
					aEspecie = "02";
					break;

				case "NS":
					aEspecie = "03";
					break;

				case "RC":
					aEspecie = "05";
					break;

				case "DS":
					aEspecie = "10";
					break;

				case "SD":
					aEspecie = "08";
					break;

				case "CE":
					aEspecie = "09";
					break;

				case "PD":
					aEspecie = "98";
					break;

				default:
					aEspecie = titulo.EspecieDoc;
					break;
			}

			//Pegando Tipo de Sacado}
			string aTipoSacado;
			switch (titulo.Sacado.Pessoa)
			{
				case Pessoa.Fisica:
					aTipoSacado = "01";
					break;

				case Pessoa.Juridica:
					aTipoSacado = "02";
					break;

				default:
					aTipoSacado = "99";
					break;
			}

			//Codigo desnecessario ?
			//var mensagemCedente = titulo.Mensagem.AsString();
			//if (mensagemCedente.Length > 60)
			//	mensagemCedente = mensagemCedente.Substring(1, 60);

			var contaDigito = titulo.Parent.Cedente.Conta.OnlyNumbers();
			contaDigito += titulo.Parent.Cedente.ContaDigito;
			contaDigito = contaDigito.ZeroFill(11);

			var diasprotesto = titulo.DataProtesto.HasValue ? string.Format("{0:00}", 
				titulo.DataProtesto.Value.Date.Subtract(titulo.Vencimento.Date).Days) : "  ";

			var wLinha = new StringBuilder();
			wLinha.Append('1');                                                            //ID Registro
			wLinha.Append("02");                                                           //C�digo de Inscri��o
			wLinha.Append(titulo.Parent.Cedente.CNPJCPF.OnlyNumbers().ZeroFill(14));       //N�mero de inscri��o do Cliente (CPF/CNPJ)
			wLinha.Append('0');                                                            //Zero
			wLinha.Append(titulo.Parent.Cedente.Agencia.OnlyNumbers().ZeroFill(4));        //Agencia cedente
			wLinha.Append("55");                                                           //Sub-Conta
			wLinha.Append(contaDigito);
			wLinha.Append("".FillLeft(2));                                                 //uso banco
			wLinha.Append(titulo.SeuNumero.FillLeft(25));                                  //Numero de Controle do Participante
			wLinha.Append(MontarCampoNossoNumero(titulo).OnlyNumbers());                   //Nosso Numero tam 10 + digito tam 1
			wLinha.Append(titulo.DataDesconto.HasValue ?
				titulo.DataDesconto.Value.ToString("ddMMyy") : "000000");                  //data limite para desconto (2)
			wLinha.Append(titulo.ValorDesconto.ToDecimalString(11));                       //valor desconto (2)
			wLinha.Append(titulo.DataDesconto.HasValue ?
						 titulo.DataDesconto.Value.ToString("ddMMyy") : "000000");         //data limite para desconto (3)
			wLinha.Append(titulo.ValorDesconto.ToDecimalString(11));                       //valor desconto (3)
			wLinha.Append('1');                                                            //1 - Cobran�a Simples
			wLinha.Append(ocorrencia.ZeroFill(2));                                         //ocorrencia
			wLinha.Append(titulo.NumeroDocumento.FillLeft(10));                            //numero da duplicata
			wLinha.AppendFormat("{0:ddMMyy}", titulo.Vencimento);                          //vencimento
			wLinha.Append(titulo.ValorDocumento.ToDecimalString());                        //valor do titulo
			wLinha.Append("399");                                                          //banco cobrador
			wLinha.Append("00000");                                                        //Ag�ncia depositaria
			wLinha.Append(aEspecie.FillLeft(2) + 'N');                                     //Especie do documento + Idntifica��o(valor fixo N)
			wLinha.AppendFormat("{0:ddMMyy}", titulo.DataDocumento);                       //Data de Emiss�o
			wLinha.Append(titulo.Instrucao1.ZeroFill(2));                                  //instru��o 1
			wLinha.Append(titulo.Instrucao2.ZeroFill(2));                                  //instru��o 2
			wLinha.Append(titulo.ValorMoraJuros.ToDecimalString());                        //Juros de Mora
			wLinha.Append(titulo.DataDesconto.HasValue ?
				titulo.DataDesconto.Value.ToString("ddMMyy") : "000000");                 //data limite para desconto  //ADICIONEI ZERO ESTAVA E BRANCO ALFEU
			wLinha.Append(titulo.ValorDesconto.ToDecimalString());                         //valor do desconto
			wLinha.Append(titulo.ValorIOF.ToDecimalString());							   //Valor do  IOF
			wLinha.Append(titulo.ValorAbatimento.ToDecimalString());					   //valor do abatimento
			wLinha.Append(aTipoSacado);                                                    //codigo de inscri��o do sacado
			wLinha.Append(titulo.Sacado.CNPJCPF.OnlyNumbers().ZeroFill(14));               //numero de inscri��o do sacado
			wLinha.Append(titulo.Sacado.NomeSacado.FillLeft(40));                          //nome sacado
			wLinha.Append((titulo.Sacado.Logradouro + titulo.Sacado.Numero +
					   titulo.Sacado.Complemento).FillLeft(38));                           //endere�o sacado
			wLinha.Append("".FillLeft(2));			                                       //Instru��o de  n�o recebimento do bloqueto
			wLinha.Append(titulo.Sacado.Bairro.FillLeft(12));                              //bairro sacado
			wLinha.Append(titulo.Sacado.CEP.OnlyNumbers().ZeroFill(8));                    //cep do sacado
			wLinha.Append(titulo.Sacado.Cidade.FillLeft(15));                              //cidade do sacado
			wLinha.Append(titulo.Sacado.UF.FillLeft(2));                                   //uf do sacado
			wLinha.Append(titulo.Sacado.Avalista.FillLeft(39));                            //nome do sacado
			wLinha.Append(tipoBoleto);                                                     //Tipo de Bloqueto
			wLinha.Append(diasprotesto);                                                   //nro de dias para protesto
			wLinha.Append("9");                                                            //Tipo Moeda
			wLinha.AppendFormat("{0:000000}", aRemessa.Count + 1);

			aRemessa.Add(wLinha.ToString().ToUpper());
		}

		/// <summary>
		/// Gerars the registro trailler400.
		/// </summary>
		/// <param name="aRemessa">A remessa.</param>
        public override void GerarRegistroTrailler400(List<string> aRemessa)
        {
            var wLinha = new StringBuilder();
            wLinha.Append('9');
            wLinha.Append("".FillRight(393));                       // ID Registro
            wLinha.AppendFormat("{0:000000}", aRemessa.Count + 1);  // Contador de Registros
            
            aRemessa.Add(wLinha.ToString().ToUpper());
        }

		/// <summary>
		/// Lers the retorno400.
		/// </summary>
		/// <param name="aRetorno">A retorno.</param>
		/// <exception cref="ACBrException">@Agencia\Conta do arquivo inv�lido</exception>
		/// <exception cref="ACBrException">@Agencia\Conta do arquivo inv�lido</exception>
        public override void LerRetorno400(List<string> aRetorno)
        {
			Guard.Against<ACBrException>(aRetorno[0].ExtrairInt32DaPosicao(77, 79) != Numero,
				"{0} n�o � um arquivo de retorno do {1}", Banco.Parent.NomeArqRetorno, Nome);

			var rCedente = aRetorno[0].ExtrairDaPosicao(47, 76);
			var rCodigoCedente = aRetorno[0].ExtrairInt32DaPosicao(109, 118);
			var rAgencia = aRetorno[0].ExtrairDaPosicao(28, 31);
			var rConta = aRetorno[0].ExtrairDaPosicao(38, 43);
			var rDigitoConta  = aRetorno[0].ExtrairDaPosicao(44);

			var cnr = aRetorno[0].ExtrairDaPosicao(12, 26) == "COBRANCA CNR";
			
			Banco.Parent.NumeroArquivo = aRetorno[0].ExtrairInt32DaPosicao(389, 393);
			Banco.Parent.DataArquivo = aRetorno[0].ExtrairDataDaPosicao(95, 100, "ddMMyy");

			if (!cnr)
				Banco.Parent.DataCreditoLanc = aRetorno[0].ExtrairDataDaPosicao(120, 125, "ddMMyy");

			string rCNPJCPF;
			switch (aRetorno[1].ExtrairInt32DaPosicao(2, 3))
			{
				case 11:
					rCNPJCPF = aRetorno[1].ExtrairDaPosicao(7, 17);
					break;

				case 14:
					rCNPJCPF = aRetorno[1].ExtrairDaPosicao(4, 17);
					break;

				default:
					rCNPJCPF = string.Empty;
					break;
			}

			if (!rCNPJCPF.IsEmpty())
			{
				Guard.Against<ACBrException>(
					Banco.Parent.LeCedenteRetorno && rCNPJCPF != Banco.Parent.Cedente.CNPJCPF.OnlyNumbers(),
					"CNPJ\\CPF do arquivo inv�lido");
			}

			Guard.Against<ACBrException>(
				!Banco.Parent.LeCedenteRetorno && rCodigoCedente != Banco.Parent.Cedente.CodigoCedente.OnlyNumbers().ToInt32(),
				"Cedente do arquivo inv�lido{0}Informado = {1}{0}Esperado = {2}", Environment.NewLine,
				Banco.Parent.Cedente.CodigoCedente.OnlyNumbers(), rCodigoCedente);

			Guard.Against<ACBrException>(
				!Banco.Parent.LeCedenteRetorno && rAgencia != Banco.Parent.Cedente.Agencia.OnlyNumbers(),
				"Agencia do arquivo inv�lido{0}Informado = {1}{0}Esperado = {2}", Environment.NewLine,
				Banco.Parent.Cedente.Agencia.OnlyNumbers(), rAgencia);

			Guard.Against<ACBrException>(
				!Banco.Parent.LeCedenteRetorno && rConta != Banco.Parent.Cedente.Conta.OnlyNumbers(),
				"Conta do arquivo inv�lido{0}Informado = {1}{0}Esperado = {2}", Environment.NewLine,
				Banco.Parent.Cedente.Conta.OnlyNumbers(), rConta);

			if (Banco.Parent.LeCedenteRetorno)
			{
				Banco.Parent.Cedente.Nome = rCedente;
				if (!cnr)
					Banco.Parent.Cedente.CNPJCPF = rCNPJCPF;
				
				Banco.Parent.Cedente.Agencia = rAgencia;
				Banco.Parent.Cedente.AgenciaDigito = "";
				Banco.Parent.Cedente.Conta = rConta;
				Banco.Parent.Cedente.ContaDigito = rDigitoConta;
				switch (aRetorno[1].ExtrairInt32DaPosicao(2, 3))
				{
					case 11:
						Banco.Parent.Cedente.TipoInscricao = PessoaCedente.Fisica;
						break;

					default:
						Banco.Parent.Cedente.TipoInscricao = PessoaCedente.Juridica;
						break;
				}
			}

			Banco.Parent.ListadeBoletos.Clear();
			for (var i = 1; i < aRetorno.Count - 2; i++)
			{
				var linha = aRetorno[i];
				if (linha.ExtrairDaPosicao(1, 1) != "1")
					continue;

				var titulo = Banco.Parent.CriarTituloNaLista();
				titulo.SeuNumero = cnr ? linha.ExtrairDaPosicao(117, 122) : linha.ExtrairDaPosicao(38, 62);

				titulo.NumeroDocumento = linha.ExtrairDaPosicao(117, 126);

				var codOcorrencia = linha.ExtrairInt32OpcionalDaPosicao(109, 110).HasValue ?
					                 linha.ExtrairInt32DaPosicao(109, 110) : 0;

				titulo.OcorrenciaOriginal.Tipo = CodOcorrenciaToTipo(codOcorrencia);

				if (codOcorrencia == 19)
				{
					var motivoLinha = linha.ExtrairDaPosicao(295);
					if (motivoLinha == "A")
					{
						titulo.MotivoRejeicaoComando.Add(motivoLinha);
						titulo.DescricaoMotivoRejeicaoComando.Add("A - Aceito");
					}
					else
					{
						titulo.MotivoRejeicaoComando.Add(motivoLinha);
						titulo.DescricaoMotivoRejeicaoComando.Add("D - Desprezado");
					}
				}
				else
				{
					var ocorrencia = titulo.OcorrenciaOriginal.Tipo;
					var motivoLinha = 319;
					for (var j = 0; j < 4; j++)
					{
						var codMotivo = linha.ExtrairInt32OpcionalDaPosicao(motivoLinha, motivoLinha + 1).HasValue ?
										linha.ExtrairInt32DaPosicao(motivoLinha, motivoLinha + 1) : 0;

						//Somente estas ocorrencias possuem motivos 00
						if (j == 0 && codOcorrencia.IsIn(2, 6, 9, 10, 15, 17))
						{
							titulo.MotivoRejeicaoComando.Add(codMotivo.ToString());
							titulo.DescricaoMotivoRejeicaoComando.Add(CodMotivoRejeicaoToDescricao(ocorrencia, codMotivo));
						}
						else
						{
							//Apos o 1� motivo os 00 significam que n�o existe mais motivo
							if (codMotivo == 0)
							{
								titulo.MotivoRejeicaoComando.Add("00");
								titulo.DescricaoMotivoRejeicaoComando.Add("Sem Motivo");
							}
							else
							{
								titulo.MotivoRejeicaoComando.Add(codMotivo.ToString());
								titulo.DescricaoMotivoRejeicaoComando.Add(CodMotivoRejeicaoToDescricao(ocorrencia, codMotivo));
							}
						}

						//Incrementa a coluna dos motivos
						motivoLinha += 2;
					}
				}

				titulo.DataOcorrencia = linha.ExtrairDataDaPosicao(111, 116, "ddMMyy");
				titulo.Vencimento = linha.ExtrairDataDaPosicao(147, 152, "ddMMyy");
				if (cnr)
					titulo.DataCredito = linha.ExtrairDataDaPosicao(83, 88, "ddMMyy");

				titulo.ValorDocumento = linha.ExtrairDecimalDaPosicao(153, 165);
				titulo.ValorDespesaCobranca = linha.ExtrairDecimalDaPosicao(176, 188);
				titulo.ValorAbatimento = linha.ExtrairDecimalDaPosicao(228, 240);
				titulo.ValorDesconto = linha.ExtrairDecimalDaPosicao(241, 253);
				titulo.ValorRecebido = linha.ExtrairDecimalDaPosicao(254, 266);
				titulo.ValorMoraJuros = linha.ExtrairDecimalDaPosicao(267, 279);

				titulo.Carteira = linha.ExtrairDaPosicao(108);

				titulo.NossoNumero = cnr ? linha.ExtrairDaPosicao(63, 75) : 
					                       linha.ExtrairDaPosicao(127, 137);
			}
        }

        #endregion Methods
    }
}