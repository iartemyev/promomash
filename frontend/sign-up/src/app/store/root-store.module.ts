import {
	DefaultRouterStateSerializer,
	routerReducer,
	StoreRouterConnectingModule,
} from '@ngrx/router-store';
import { EffectsModule } from '@ngrx/effects';
import { SignUpStoreModule } from './signup-store/signup-store.module';
import { StoreModule } from '@ngrx/store';
import { NgModule } from '@angular/core';

@NgModule({
	declarations: [],
	imports: [
		SignUpStoreModule,
		StoreModule.forRoot(
			{ router: routerReducer },
			{
				runtimeChecks: {
					strictStateImmutability: false,
					strictActionImmutability: false,
				},
			},
		),
		EffectsModule.forRoot([]),
		StoreRouterConnectingModule.forRoot({
			serializer: DefaultRouterStateSerializer,
		}),
	],
})
export class RootStoreModule {}
