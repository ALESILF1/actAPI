import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';
import { HttpClientModule } from '@angular/common/http'; // ✅ Importar para standalone
import { ToastrModule } from 'ngx-toastr';
import { routes } from './app.routes';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

export const appConfig: ApplicationConfig = {
  providers: [
   provideRouter(routes),
   importProvidersFrom(HttpClientModule),
   importProvidersFrom(BrowserAnimationsModule),
   importProvidersFrom(
     ToastrModule.forRoot({
       timeOut: 3000,
       positionClass: 'toast-top-center',
       preventDuplicates: true,
     })
   ),
 ]
};

