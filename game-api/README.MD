## Publicación back en Heroku

```bash
# construir la imagen de docker
docker build -t worldofdarknet .

# este comando es para hacer la prueba de que funciona
docker run -d -p 8080:80 --name abc worldofdarknet

# enviar a Heroku
heroku container:push web --remote heroku-wod-back

# publicar!!!!
heroku container:release web --remote heroku-wod-back

```

## Docker db (en la ventana de Nugget de Visual Studio)

```bash
Add-Migration -Name "InitMigration" -Project "Game.Infrastructure" -StartupProject "Game.Api.Host" -Verbose

Update-Database -Project "Game.Infrastructure" -StartupProject "Game.Api.Host" -Verbose

Remove-Migration -Project "Game.Infrastructure" -StartupProject "Game.Api.Host" -Verbose # elimina la última migración hecha (por ejemplo si falta un campo por añadir)
```

## The Bible and others

```bash
https://dev.to/alrobilliard/deploying-net-core-to-heroku-1lfe

https://devcenter.heroku.com/articles/container-registry-and-runtime

https://devcenter.heroku.com/articles/heroku-cli-commands
```
