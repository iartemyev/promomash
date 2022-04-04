import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoggerService } from './shared/service/logger.service';
import { AppSettingsService } from './shared/service/app-settings.service';
import { RestApiService } from './shared/service/rest-api/rest-api.service';
import { HTTP_INTERCEPTORS, HttpClient, HttpClientModule } from '@angular/common/http';
import { StripUndefinedParamsInterceptor } from './shared/interceptor/strip-undefined-params.interceptor';
import { ErrorInterceptor } from './shared/interceptor/error.interceptor';
import { RouterModule } from '@angular/router';
import { RootStoreModule } from './store';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from '../environments/environment';
import { SharedModule } from './shared/shared.module';
import { ContentModule } from './content/content.module';

@NgModule({
	declarations: [AppComponent],
	imports: [
		BrowserModule,
		AppRoutingModule,
		BrowserAnimationsModule,
		RouterModule,
		RootStoreModule,
		ContentModule,
		!environment.production ? StoreDevtoolsModule.instrument() : [],
		SharedModule.forRoot(),
		HttpClientModule,
	],
	providers: [
		LoggerService,
		{
			provide: AppSettingsService,
			deps: [LoggerService],
		},
		{
			provide: RestApiService,
			deps: [HttpClient, AppSettingsService, LoggerService],
		},
		{
			provide: HTTP_INTERCEPTORS,
			useClass: StripUndefinedParamsInterceptor,
			multi: true,
		},
		{
			provide: HTTP_INTERCEPTORS,
			useClass: ErrorInterceptor,
			multi: true,
		},
	],
	bootstrap: [AppComponent],
})
export class AppModule {}
