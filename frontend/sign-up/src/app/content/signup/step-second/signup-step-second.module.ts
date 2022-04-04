import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SignupStepSecondComponent } from './signup-step-second.component';
import { SignupStepSecondRoutingModule } from './signup-step-second-routing.module';

@NgModule({
	declarations: [SignupStepSecondComponent],
	imports: [CommonModule, SignupStepSecondRoutingModule],
})
export class SignupStepSecondModule {}
