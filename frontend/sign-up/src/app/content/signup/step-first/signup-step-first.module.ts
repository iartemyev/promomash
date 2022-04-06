import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignupStepFirstComponent } from './signup-step-first.component';
import { SignupStepFirstRoutingModule } from './signup-step-first-routing.module';
import { FormsModule } from '@angular/forms';
import { MatCardModule } from '@angular/material/card';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
	declarations: [SignupStepFirstComponent],
	imports: [
		CommonModule,
		SignupStepFirstRoutingModule,
		FormsModule,
		MatCardModule,
		MatInputModule,
		MatButtonModule,
	],
})
export class SignupStepFirstModule {}
