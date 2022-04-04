import { NgModule } from '@angular/core';
import { StoreModule } from '@ngrx/store';
import { SignUpReducer, SignUpState } from './index';
import { EffectsModule } from '@ngrx/effects';
import { SignUpEffect } from './signup.effect';

@NgModule({
	declarations: [],
	imports: [
		StoreModule.forFeature(SignUpState.featureKey, SignUpReducer.machineReducer),
		EffectsModule.forFeature([SignUpEffect]),
	],
})
export class SignUpStoreModule {}
