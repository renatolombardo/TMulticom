import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { JogoComponent } from './jogo/jogo.component';
import { CreateEditJogoComponent } from './jogo/create-edit-jogo/create-edit-jogo.component';
import { EmprestarJogoComponent } from './jogo/emprestar-jogo/emprestar-jogo.component';
import { JogoService } from './services/jogo.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    JogoComponent,
    CreateEditJogoComponent,
    EmprestarJogoComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'jogo', component: JogoComponent, canActivate: [AuthorizeGuard] },
      { path: 'jogo/inserir', component: CreateEditJogoComponent, canActivate: [AuthorizeGuard] },
      { path: 'jogo/editar/:id', component: CreateEditJogoComponent, canActivate: [AuthorizeGuard] },
      { path: 'jogo/emprestar/:id', component: EmprestarJogoComponent, canActivate: [AuthorizeGuard] },
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    JogoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
