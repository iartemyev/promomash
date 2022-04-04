import { RouterModule, Routes } from '@angular/router';
import { SignupResultComponent } from './signup-result.component';
import { NgModule } from '@angular/core';

const routes: Routes = [
	{
		path: '',
		component: SignupResultComponent,
	},
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule],
})
export class SignupResultRoutingModule {}
