import { NgModule } from '@angular/core';
import { SignupResultComponent } from './signup-result.component';
import { CommonModule } from '@angular/common';
import { SignupResultRoutingModule } from './signup-result-routing.module';

@NgModule({
	declarations: [SignupResultComponent],
	imports: [CommonModule, SignupResultRoutingModule],
})
export class SignupResultModule {}
