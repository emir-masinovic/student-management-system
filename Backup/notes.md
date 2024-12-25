##### Frontend:

- Point Azure to Angular build folder properly:
  - `Settings/Configuration/Path mappings/Physical Path` - Add `browser` so it is `site\wwwroot\browser`
  - NOTE: From Angular 17 and onwards, `ng build` makes a `browser` folder
- Environment folder and script not made in angular.json:
  - Fresh Angular project doesn't provide environments folder, files, or script for executing (at least not for v19)

##### Backend:

- Add frontend URL or IP to `API/CORS/Allowed Origins`
- Add DB connection strings to environment variables: `Settings/Environment variables/Connection strings`. This way, password won't be commited accidentally when working from local machine

##### Database:

- Allow access to the backend in the cloud and on local machine:
  - `DB server resource/Security/Networking/Public access`. Check boxes
  - [x] `Selected Networks`
  - [x] `Exceptions` - Allow Azure services...
  - Add rule and IP for local machine so it can access DB in the cloud
