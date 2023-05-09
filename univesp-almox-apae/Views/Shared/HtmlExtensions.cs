using System.Linq;
using System.Text;

namespace Microsoft.AspNetCore.Mvc.Rendering
{
    public static class HtmlExtensions
    {
        public static string HoverController(this IHtmlHelper helper, string controller, string customClass = "active")
        {
            string? currentController = helper.ViewContext.RouteData.Values["Controller"].ToString();
            
            if (currentController.ToLower() == controller.ToLower())
            {
                return customClass;
            }

            return string.Empty;
        }

        public static string Hover(this IHtmlHelper helper, string controller, string action, string customClass = "active")
        {
            var currentController = helper.ViewContext.RouteData.Values["Controller"].ToString();
           
            var currentAction = helper.ViewContext.RouteData.Values["Action"].ToString();
            
            if (currentAction.ToLower() == action.ToLower() && currentController.ToLower() == controller.ToLower())
            {
                return customClass;
            }

            return string.Empty;
        }

        public static string PaginacaoRemoto(
            this IHtmlHelper helper,
            int paginaAtual,
            int registrosPorPagina,
            int totalRegistros,
            string form)
        {
            int paginas = totalRegistros / registrosPorPagina;
            
            int resto = totalRegistros % registrosPorPagina;
           
            if (resto > 0)
            {
                paginas++;
            }

            StringBuilder lista = new();
            int ultima = paginas;
            int primeira = 1;
           
            if (paginas > 9)
            {
                ultima = 9;
                if (paginaAtual > 4)
                {
                    if (paginas <= (paginaAtual + 4))
                    {
                        ultima = paginas;
                        primeira = paginas - 8;
                    }
                    else
                    {
                        ultima = 4 + paginaAtual;
                        primeira = paginaAtual - 4;
                    }
                }
            }

            if (paginas > 1)
            {
                lista.Append($@"<nav class='paginacao' aria-label='Resultados da busca'>");
                lista.Append($@"<ul class='pagination'>");

                if (paginaAtual > 1)
                {
                    lista.Append($@"
                        <li class='page-item'>
                            <a class='page-link' onclick=$('{form}').find('[type=hidden][name*=Pagina]').val({(paginaAtual - 1)}),$('{form}').submit()>
                                <span aria-hidden='true'>&laquo;</span>
                                <span class='sr-only'>Anterior</span>
                            </a>
                        </li>"
                    );
                }
                else
                {
                    lista.Append($@"
                        <li class='page-item disabled'>
                            <a class='page-link' tabindex='-1'>
                                <span aria-hidden='true'>&laquo;</span>
                                <span class='sr-only'>Anterior</span>
                            </a>
                        </li>"
                    );
                }
                for (int i = primeira; i <= ultima; i++)
                {
                    string classe = string.Empty;
                    if (i == paginaAtual)
                    {
                        classe = " active";
                    }
                    lista.Append($@"
                        <li class='page-item {classe}'>
                            <a class='page-link' onclick=$('{form}').find('[type=hidden][name*=Pagina]').val({i}),$('{form}').submit()>{i}</a>
                        </li>"
                    );
                }
                if (paginaAtual < paginas)
                {
                    lista.Append(@$"
                        <li class='page-item'>
                            <a class='page-link' onclick=$('{form}').find('[type=hidden][name*=Pagina]').val({(paginaAtual + 1)}),$('{form}').submit() aria-label='Next'>
                                <span aria-hidden='true'>&raquo;</span>
                                <span class='sr-only'>Próximo</span>
                            </a>
                        </li>"
                    );
                }
                else
                {
                    lista.Append(@$"
                        <li class='page-item disabled'>
                            <a class='page-link' tabindex='-1'>
                                <span aria-hidden='true'>&raquo;</span>
                                <span class='sr-only'>Próximo</span>
                            </a>
                        </li>"
                    );
                }
                lista.Append(@$"</ul>");
                lista.Append(@$"</nav>");
            }
            return lista.ToString();
        }
    }
}
