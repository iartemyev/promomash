import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignupStepFirstComponent } from './signup-step-first.component';
import { SignupStepFirstRoutingModule } from './signup-step-first-routing.module';

@NgModule({
	declarations: [SignupStepFirstComponent],
	imports: [CommonModule, SignupStepFirstRoutingModule],
})
export class SignupStepFirstModule {}
