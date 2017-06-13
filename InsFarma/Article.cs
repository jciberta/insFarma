using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace InsFarma
{
    /// <summary>
    /// Formulari de recerca dels articles.
    /// </summary>
    public static class ArticleRecerca
    {
        public static void Mostra(SqlConnection con)
        {
            XFormRecercaConstructor frm = new XFormRecercaConstructor(con, "ARTICLE", "article_id", "referencia,descripcio");
            frm.AfegeixTitol("Articles");
            frm.AfegeixFitxa(typeof(ArticleFitxa));
            frm.Mostra();
        }

        public static string Busca(SqlConnection con)
        {
            XFormRecercaConstructor frm = new XFormRecercaConstructor(con, "ARTICLE", "article_id", "referencia,descripcio");
            frm.AfegeixTitol("Articles");
            return frm.Busca();
        }
    }

    /// <summary>
    /// Formulari de fitxa dels articles.
    /// </summary>
    public static class ArticleFitxa
    {
        public static void Alta(SqlConnection con)
        {
            XFormFitxaSimpleConstructor frm = new XFormFitxaSimpleConstructor(con, "ARTICLE", "article_id");
            CreaUI(frm);
            frm.Alta();
        }

        public static void Mostra(SqlConnection con, int id)
        {
            XFormFitxaSimpleConstructor frm = new XFormFitxaSimpleConstructor(con, "ARTICLE", "article_id");
            CreaUI(frm);
            frm.Mostra(id);
        }

        private static void CreaUI(XFormFitxaSimpleConstructor frm)
        {
            frm.AfegeixCadena("Referència", "referencia", 100);
            frm.AfegeixCadena("Descripció", "descripcio", 200, FormFitxaOpcions.Obligatori | FormFitxaOpcions.AlCostat);
            frm.AfegeixEspai();
            frm.AfegeixData("Data alta", "data_alta");
            frm.AfegeixLlistaDB("Família", "familia_article_id", 200, "FAMILIA_ARTICLE", "familia_article_id", "descripcio", typeof(FamiliaArticleRecercaFitxa));
            frm.AfegeixLlistaDB("Marca", "marca_article_id", 200, "MARCA_ARTICLE", "marca_article_id", "descripcio", typeof(MarcaArticleRecercaFitxa));
            frm.AfegeixLlista("Ubicació", "ubicacio", 200, new int[] { 1, 2, 3 }, new string[] { "0%", "10%", "20%" });
        }
    }

    /// <summary>
    /// Formulari de recerca/fitxa de les famílies d'articles.
    /// </summary>
    public static class FamiliaArticleRecercaFitxa
    {
        public static void Mostra(SqlConnection con)
        {
            XFormRecercaFitxaConstructor frm = new XFormRecercaFitxaConstructor(con, "FAMILIA_ARTICLE", "familia_article_id", "familia_article_id,descripcio");
            frm.AfegeixTitol("Famílies d'articles");
            frm.Mostra();
        }

        public static string Busca(SqlConnection con)
        {
            XFormRecercaFitxaConstructor frm = new XFormRecercaFitxaConstructor(con, "FAMILIA_ARTICLE", "familia_article_id", "familia_article_id,descripcio");
            frm.AfegeixTitol("Famílies d'articles");
            return frm.Busca();
        }
    }

    /// <summary>
    /// Formulari de recerca/fitxa de les marques d'articles.
    /// </summary>
    public static class MarcaArticleRecercaFitxa
    {
        public static void Mostra(SqlConnection con)
        {
            XFormRecercaFitxaConstructor frm = new XFormRecercaFitxaConstructor(con, "MARCA_ARTICLE", "marca_article_id", "marca_article_id,descripcio");
            frm.AfegeixTitol("Marques d'articles");
            frm.Mostra();
        }

        public static string Busca(SqlConnection con)
        {
            XFormRecercaFitxaConstructor frm = new XFormRecercaFitxaConstructor(con, "MARCA_ARTICLE", "marca_article_id", "marca_article_id,descripcio");
            frm.AfegeixTitol("Marques d'articles");
            return frm.Busca();
        }
    }


}
