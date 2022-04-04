import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { SignupComponent } from './signup.component';

const routes: Routes = [
	{
		path: '',
		component: SignupComponent,
		children: [
			{
				path: 'step-1',
				loadChildren: () =>
					import('./step-first/signup-step-first.module').then((m) => m.SignupStepFirstModule),
			},
			{
				path: 'step-2',
				loadChildren: () =>
					import('./step-second/signup-step-second.module').then((m) => m.SignupStepSecondModule),
			},
			{
				path: 'result',
				loadChildren: () =>
					import('./result/signup-result.module').then((m) => m.SignupResultModule),
			},
		],
	},
];

@NgModule({
	imports: [RouterModule.forChild(routes)],
	exports: [RouterModule],
})
export class SignupRoutingModule {}
