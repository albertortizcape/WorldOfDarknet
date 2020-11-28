namespace Microsoft.AspNetCore.Builder
{
    static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddSwaggerConfigure(this IApplicationBuilder builder)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            builder.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            builder.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Game API V1");
                //c.RoutePrefix = string.Empty;
            });

            return builder;
        }

    }
}
