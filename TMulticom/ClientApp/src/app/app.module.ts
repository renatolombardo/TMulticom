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
import { AmigoComponent } from './amigo/amigo.component';
import { AmigoService } from './services/amigo.service';
import { CreateEditAmigoComponent } from './amigo/create-edit-amigo/create-edit-amigo.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    JogoComponent,
    CreateEditJogoComponent,
    EmprestarJogoComponent,
    AmigoComponent,
    CreateEditAmigoComponent

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
      { path: 'amigo', component: AmigoComponent, canActivate: [AuthorizeGuard] },
      { path: 'amigo/inserir', component: CreateEditAmigoComponent, canActivate: [AuthorizeGuard] },
      { path: 'amigo/editar/:id', component: CreateEditAmigoComponent, canActivate: [AuthorizeGuard] },
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    JogoService,
    AmigoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
