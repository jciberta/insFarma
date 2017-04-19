using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace InsFarma
{
    /// <summary>
    /// Formulari de recerca de l'agenda.
    /// </summary>
    public static class AgendaRecerca
    {
        public static void Mostra(SqlConnection con)
        {
            XFormRecercaConstructor frm = new XFormRecercaConstructor(con, "AGENDA", "agenda_id", "nom_comercial,nom_fiscal");
            frm.AfegeixTitol("Agenda");
            frm.AfegeixFitxa(typeof(AgendaFitxa));
            frm.Mostra();
        }

        public static string Busca(SqlConnection con)
        {
            XFormRecercaConstructor frm = new XFormRecercaConstructor(con, "AGENDA", "agenda_id", "nom_comercial,nom_fiscal");
            frm.AfegeixTitol("Agenda");
            return frm.Busca();
        }
    }

    /// <summary>
    /// Formulari de fitxa de l'agenda.
    /// </summary>
    public static class AgendaFitxa
    {
        public static void Alta(SqlConnection con)
        {
            XFormFitxaSimpleConstructor frm = new XFormFitxaSimpleConstructor(con, "AGENDA", "agenda_id");
            CreaUI(frm);
            frm.Alta();
        }

        public static void Mostra(SqlConnection con, int id)
        {
            XFormFitxaSimpleConstructor frm = new XFormFitxaSimpleConstructor(con, "AGENDA", "agenda_id");
            CreaUI(frm);
            frm.Mostra(id);
        }

        private static void CreaUI(XFormFitxaSimpleConstructor frm)
        {
            frm.AfegeixCadena("Nom comercial", "nom_comercial", 200, FormFitxaOpcions.Obligatori);
            frm.AfegeixCadena("NIF", "nif", 100);
            frm.AfegeixCadena("Nom fiscal", "nom_fiscal", 200, FormFitxaOpcions.Obligatori);
            frm.AfegeixLlistaDB("Classificació", "classificacio_agenda_id", 200, "CLASSIFICACIO_AGENDA", "classificacio_agenda_id", "nom", typeof(ClassificacioAgendaRecercaFitxa));
        }
    }

    /// <summary>
    /// Formulari de recerca/fitxa de la classificació de l'agenda.
    /// </summary>
    public static class ClassificacioAgendaRecercaFitxa
    {
        public static void Mostra(SqlConnection con)
        {
            XFormRecercaFitxaConstructor frm = new XFormRecercaFitxaConstructor(con, "CLASSIFICACIO_AGENDA", "classificacio_agenda_id", "nom");
            frm.AfegeixTitol("Classificació de l'agenda");
            frm.Mostra();
        }

        public static string Busca(SqlConnection con)
        {
            XFormRecercaFitxaConstructor frm = new XFormRecercaFitxaConstructor(con, "CLASSIFICACIO_AGENDA", "classificacio_agenda_id", "nom");
            frm.AfegeixTitol("Classificació de l'agenda");
            return frm.Busca();
        }
    }


}
