import { Component, OnInit } from '@angular/core';
import { LoggerService } from '../../../shared/service/logger.service';
import { RouterFacade } from '../../../shared/facade/router.facade';

@Component({
	selector: 'app-signup-step-second',
	templateUrl: './signup-step-second.component.html',
	styleUrls: ['./signup-step-second.component.scss'],
})
export class SignupStepSecondComponent implements OnInit {
	public constructor(private _logger: LoggerService, private _router: RouterFacade) {}

	public ngOnInit(): void {
		this._logger.info('SignupStepSecondComponent ngOnInit');
	}

	public onClick($event: MouseEvent) {
		console.log($event);
		this._router.backward();
	}
}
