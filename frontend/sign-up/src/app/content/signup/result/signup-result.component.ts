import { Component, OnInit } from '@angular/core';
import { LoggerService } from '../../../shared/service/logger.service';

@Component({
	selector: 'app-signup-result',
	templateUrl: './signup-result.component.html',
	styleUrls: ['./signup-result.component.scss'],
})
export class SignupResultComponent implements OnInit {
	public constructor(private _logger: LoggerService) {}

	public ngOnInit(): void {
		this._logger.info('SignupResultComponent ngOnInit');
	}
}
