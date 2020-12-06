# darknet-view

> My splendiferous Nuxt.js project

## Build Setup

```bash
# install dependencies
$ npm install

# serve with hot reload at localhost:3000
$ npm run dev

# build for production and launch server
$ npm run build
$ npm run start

# generate static project
$ npm run generate
```

For detailed explanation on how things work, check out [Nuxt.js docs](https://nuxtjs.org).

## Publicación front en Heroku

```bash
# agregar el repo de front:
$ git remote add heroku-wod-view https://git.heroku.com/world-of-darknet-view.git

# agregar el repo de back:
$ git remote add heroku-wod-back https://git.heroku.com/world-of-darknet-back.git

# establecer el container, porque js no despliega por defecto en Heroku, y da un error de: No default language could be detected for this app
$ heroku stack:set container --remote heroku-front

# una vez que en el package.json está establecido el comando para desplegar hacer un run publish
# comando en package: "publish": "cd ../../ && git subtree push --prefix game-front/ heroku-wod-view master || true"
$ npm run publish

# otro comando, parece que para los logs
$ heroku logs --remote heroku-game --tail
```

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

## The Bible and others

```bash
https://dev.to/alrobilliard/deploying-net-core-to-heroku-1lfe

https://devcenter.heroku.com/articles/container-registry-and-runtime

https://devcenter.heroku.com/articles/heroku-cli-commands
```
