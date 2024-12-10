using InovaFinancas.Api.Comun.Api;
using InovaFinancas.Api.EndPoints.Categorias;
using InovaFinancas.Api.EndPoints.Transacaoes;

namespace InovaFinancas.Api.EndPoints
{
	public static class EndPoints
	{
		public static void MapEndPoints(this WebApplication app)
		{
			var endpont = app.MapGroup("");

			endpont.MapGroup("/").WithTags("Healh Check")
				.MapGet("/", () => new { message = "Helo World" });

			endpont.MapGroup("v1/categoria")
				.WithTags("categoria")
				.RequireAuthorization()
				.MapEndepoint<CreateCategoriaEndPoint>()
				.MapEndepoint<UpdateCategoriaEndPoint>()
				.MapEndepoint<DeleteCategoriaEndPoint>()
				.MapEndepoint<GetCategoriaByIdEndPoint>()
				.MapEndepoint<GetAllCategoriaEndPoint>();

			endpont.MapGroup("v1/transacao")
				.WithTags("transcao")
				.RequireAuthorization()
				.MapEndepoint<CreateTransacaoEndPoint>()
				.MapEndepoint<UpdateTransacaoEndPoint>()
				.MapEndepoint<DeleteTransacaoEndPoint>()
				.MapEndepoint<GetTransacaoByIdEndPoint>()
				.MapEndepoint<GetTransacaoByPeriodoEndPoint>();
		}



		private static IEndpointRouteBuilder MapEndepoint<TEndPoint>(this IEndpointRouteBuilder app) where TEndPoint : IEndPoint
		{
			TEndPoint.Map(app);
			return app;
		}
	}
}
