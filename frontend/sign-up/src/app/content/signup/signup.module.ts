import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignupComponent } from './signup.component';
import { SignupRoutingModule } from './signup-routing.module';
import { SignupStep1Component } from './signup-step1/signup-step1.component';
import { SignupStep2Component } from './signup-step2/signup-step2.component';
import { MatStepperModule } from '@angular/material/stepper';
import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule } from '@angular/forms';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@NgModule({
	declarations: [SignupComponent, SignupStep1Component, SignupStep2Component],
	imports: [
		CommonModule,
		SignupRoutingModule,
		MatInputModule,
		MatSelectModule,
		MatStepperModule,
		MatButtonModule,
		ReactiveFormsModule,
		MatCheckboxModule,
		MatProgressSpinnerModule,
	],
})
export class SignupModule {}
